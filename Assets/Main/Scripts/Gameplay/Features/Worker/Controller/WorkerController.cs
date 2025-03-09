using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Extensions;
using Extensions.Spawner;
using Gameplay.Entities.Castle;
using Gameplay.Worker;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using Main.Scripts.Gameplay.Features.ResourceContainer.Controller;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using Main.Scripts.Gameplay.Features.Worker.Commands;
using Main.Scripts.Gameplay.Features.Worker.Config;
using Main.Scripts.Gameplay.Features.Worker.Models;
using Main.Scripts.Gameplay.Features.WorkerAcceptor;
using Main.Scripts.Gameplay.Installers.Tokens;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Worker.Controller
{
    public class WorkerController : IDisposable
    {
        [Inject(Id = SpawnerType.Worker)] private readonly ISpawner<WorkerGO> _spawner;
        [Inject] private BuildingController _buildingController;
        private readonly WorkerControllerConfig _config;
        private readonly ResourceContainerController _resourceContainerController;

        private readonly Dictionary<GameResourceType, List<WorkerGO>> _workers = new();
        private readonly Dictionary<GameResourceType, Stack<WorkerGO>> _freeWorkers = new();
        private readonly  Dictionary<GameResourceType,Queue<IWorkerCommand>> _workerCommandsQueue = new();
        private readonly List<IWorkerCommand> _activeWorkerCommands = new();


        private Subject<Unit> _onDestroy = new();

        WorkerController(WorkerControllerConfig config, ResourceContainerController resourceContainerController)
        {
            _config = config;
            _resourceContainerController = resourceContainerController;
        }

        private WorkerGO Spawn()
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,
                _config.MaxRadiusSpawn);
            return _spawner.Spawn(position);
        }

        private void InitWorkers()
        {
            var resourceCollectBuildings = _buildingController.GetBuildingByType(BuildingType.ResourceCollection);
            
            // TODO убрать когда будет ручное назначение добычи ресурсов
            var firstCollectBuilding = resourceCollectBuildings.First();

            foreach (var spawnConfig in _config.WorkerSpawnConfigs)
            {
                _workerCommandsQueue.Add(spawnConfig.gameResourceType, new Queue<IWorkerCommand>());
                var workers = new List<WorkerGO>();
                var freeWorkers = new Stack<WorkerGO>();
                for (int i = 0; i < spawnConfig.InitAmount; i++)
                {
                    var worker = Spawn();
                    workers.Add(worker);
                    freeWorkers.Push(worker);
                }

                _workers.Add(spawnConfig.gameResourceType, workers);
                _freeWorkers.Add(spawnConfig.gameResourceType, freeWorkers);

                var resources = _resourceContainerController
                    .GetResources(spawnConfig.gameResourceType)
                    .OrderBy(v => Vector3.Distance(v.Transform.position, firstCollectBuilding.gameObject.transform.position))
                    .ToList();

                foreach (var extractable in resources)
                {
                    AddExtractCommand(extractable, firstCollectBuilding.WorkerAcceptor);
                }
            }
        }

        private void AddExtractCommand(IExtractable extractable, IWorkerAcceptor workerAcceptor)
        {
            if (_freeWorkers.TryGetValue(extractable.Info.gameResourceType, out var freeWorkerStack))
            {
                var newCommand = new ExtractWorkerCommand(extractable, workerAcceptor);
                
                if (freeWorkerStack.IsEmpty())
                {
                    _workerCommandsQueue[extractable.Info.gameResourceType].Enqueue(newCommand);
                }
                else
                {
                    var worker = freeWorkerStack.Pop();
                    var queue = _workerCommandsQueue[extractable.Info.gameResourceType];
                    RunCommand(queue, newCommand, worker);
                }
            }
            else
            {
                Debug.LogWarning($"Стек воркеров не найден для ресурса {extractable.Info.gameResourceType}");
            }
        }

        private void RunCommand(Queue<IWorkerCommand> queue, IWorkerCommand command, WorkerGO worker)
        {
            command.Execute(worker)
                .First()
                .TakeUntil(_onDestroy)
                .Subscribe(value =>
                {
                    _activeWorkerCommands.Remove(command);

                    if (!queue.IsEmpty())
                    {
                        var nextCommand = queue.Dequeue();
                        _activeWorkerCommands.Add(nextCommand);
                        RunCommand(queue, nextCommand, worker);
                    }
                });
            _activeWorkerCommands.Add(command);
        }

        public void Init()
        {
            InitWorkers();
        }

        public void Dispose()
        {
            _onDestroy.OnNext(Unit.Default);
            _onDestroy.OnCompleted();
            _onDestroy.Dispose();
        }
    }
}