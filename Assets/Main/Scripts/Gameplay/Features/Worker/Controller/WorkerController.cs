using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Extensions;
using Extensions.Spawner;
using Gameplay.Entities.Castle;
using Gameplay.GoldMine;
using Gameplay.Installers.Tokens;
using Gameplay.Worker.Commands;
using Gameplay.Worker.Config;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Worker
{
    public class WorkerController : IDisposable
    {
        [Inject(Id = SpawnerType.Worker)] private readonly ISpawner<WorkerGO> _spawner;
        private readonly WorkerControllerConfig _config;
        private readonly ResourceContainerController _resourceContainerController;
        private readonly IDestination _destination;

        private readonly Dictionary<GameResourceType, List<WorkerGO>> _workers = new();
        private readonly Dictionary<GameResourceType, Stack<WorkerGO>> _freeWorkers = new();
        private readonly  Dictionary<GameResourceType,Queue<IWorkerCommand>> _workerCommandsQueue = new();
        private readonly List<IWorkerCommand> _activeWorkerCommands = new();


        private Subject<Unit> _onDestroy = new();

        WorkerController(WorkerControllerConfig config, ResourceContainerController resourceContainerController, IDestination destination)
        {
            _config = config;
            _resourceContainerController = resourceContainerController;
            _destination = destination;
        }

        private WorkerGO Spawn()
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,
                _config.MaxRadiusSpawn);
            return _spawner.Spawn(position);
        }

        private void InitWorkers()
        {
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
                    .OrderBy(v => Vector3.Distance(v.Transform.position, _destination.Transform.position))
                    .ToList();

                foreach (var extractable in resources)
                {
                    AddExtractCommand(extractable);
                }
            }
        }

        private void AddExtractCommand(IExtractable extractable)
        {
            if (_freeWorkers.TryGetValue(extractable.Info.gameResourceType, out var freeWorkerStack))
            {
                var newCommand = new ExtractWorkerCommand(extractable, _destination);
                
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
            Debug.Log("Следующая команда");
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