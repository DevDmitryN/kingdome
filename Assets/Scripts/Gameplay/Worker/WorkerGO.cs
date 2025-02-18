using System;
using System.Collections.Generic;
using Gameplay.Entities.Castle;
using Gameplay.GoldMine;
using Gameplay.Worker.Config;
using Gameplay.Worker.WorkerStates;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Worker
{
    public class WorkerGO : MonoBehaviour, IWorker
    {
        private Dictionary<Type, IWorkerState> _states = new();
        [CanBeNull] private IWorkerState _currentState = null;
        private Subject<Unit> _extractionComplete = new Subject<Unit>();
        
        
        [CanBeNull] public IWorkable Work { get; private set; }
        [CanBeNull] public IDestination Destination { get; private set; }
        public WorkerConfigSO Config { get; private set; }

        [Inject]
        private void Construct(WorkerConfigSO config)
        {
            Config = config;
        }
        
        private void Awake()
        {
            _states.Add(typeof(IdleWorkerState), new IdleWorkerState(this));
            _states.Add(typeof(GoToExtractWorkerState), new GoToExtractWorkerState(this));
            _states.Add(typeof(ExtractWorkerState), new ExtractWorkerState(this));
            _states.Add(typeof(CarryWorkerState), new CarryWorkerState(this));
            _states.Add(typeof(CompleteWorkerState), new CompleteWorkerState(this, () => _extractionComplete.OnNext(Unit.Default)));
            
            SetState(typeof(IdleWorkerState));
        }

        public void SetState(Type stateType)
        {
            if (_states.TryGetValue(stateType, out var newState))
            {
                _currentState?.Exit();
                newState.Enter();
                _currentState = newState;
            }
            else
            {
                Debug.LogWarning($"Состояние не найдено {stateType}");
            }
        }

        public IObservable<Unit> StartExtractProcess(IExtractable extractable, IDestination destination)
        {
            Work = extractable;
            Destination = destination;
            SetState(typeof(GoToExtractWorkerState));
            return _extractionComplete.AsObservable();
        }

        public IObservable<float> Extract(IExtractable extractable)
        {
            return Observable
                .Timer(TimeSpan.FromSeconds(Config.ExtractSpeed))
                .Select(value => extractable.Extract(Config.TakeAmount));
        }
    }
}