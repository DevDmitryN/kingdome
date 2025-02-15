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
        [Inject(Id = SpawnerType.Worker)]
        private readonly ISpawner<WorkerGO> _spawner;
        private readonly WorkerControllerConfig _config;
        private readonly GoldMineController _mineController;
        private readonly IDestination _destination;

        private readonly List<WorkerGO> _workers = new();
        private readonly Stack<WorkerGO> _freeWorkers = new();
        
        private readonly Queue<IWorkerCommand> _workerCommandsQueue = new ();
        private readonly List<IWorkerCommand> _activeWorkerCommands = new();

        private int _currentWorkerCount = 0;

        private Subject<Unit> _onDestroy = new();
        
        WorkerController(WorkerControllerConfig config, GoldMineController mineController, IDestination destination)
        {
            _config = config;
            _mineController = mineController;
            _destination = destination;

            _currentWorkerCount = config.InitCount;
        }

        public void Init()
        {
            for (int i = 0; i < _currentWorkerCount; i++)
            {
                Spawn();
            }

            var sortedMines = _mineController
                .GetMines()
                .OrderBy(v => Vector3.Distance(v.Transform.position, _destination.Transform.position))
                .ToList();
                
            foreach (var extractable in sortedMines)
            {
                AddCommand(extractable);
            }
        }

        public void Dispose()
        {
            _onDestroy.OnNext(Unit.Default);
            _onDestroy.OnCompleted();
            _onDestroy.Dispose();
        }

        private void Spawn()
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,_config.MaxRadiusSpawn);
            var worker = _spawner.Spawn(position);
            _workers.Add(worker);
            _freeWorkers.Push(worker);
        }

        private void AddCommand(IExtractable extractable)
        {
            var newCommand = new ExtractGoldCommand(extractable, _destination);
            
            if (_freeWorkers.IsEmpty())
            {
                _workerCommandsQueue.Enqueue(newCommand);
            }
            else
            {
                var worker = _freeWorkers.Pop();
                RunCommand(newCommand, worker);
            }
        }

        private void RunCommand(IWorkerCommand command, WorkerGO worker)
        {
            Debug.Log("Следующая команда");
            command.Execute(worker)
                .First()
                .TakeUntil(_onDestroy)
                .Subscribe(value =>
                {
                    _activeWorkerCommands.Remove(command);
                    
                    if (!_workerCommandsQueue.IsEmpty())
                    {
                        var nextCommand = _workerCommandsQueue.Dequeue();
                        _activeWorkerCommands.Add(nextCommand);
                        RunCommand(nextCommand, worker);
                    }
                });
            _activeWorkerCommands.Add(command);
        }
    }
}