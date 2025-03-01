using System;
using System.Collections.Generic;
using Gameplay.Core.StateMachine;
using Gameplay.Entities.Castle;
using Gameplay.GoldMine;
using Gameplay.Worker.WorkerStates;
using JetBrains.Annotations;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using Main.Scripts.Gameplay.Features.Worker.Config;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Worker
{
    public class WorkerGO : MonoBehaviour, IWorker
    {
        private IStateSwitcher _stateSwitcher;
        [CanBeNull] private IWorkerState _currentState = null;
        private Subject<Unit> _workComplete = new Subject<Unit>();
        [CanBeNull] public WorkExtractedInfo ExtractedInfo { get; private set; }
        [CanBeNull] public IWorkable Work { get; private set; }
        [CanBeNull] public IDestination Destination { get; private set; }
        public WorkerConfigSO Config { get; private set; }

        [Inject]
        private void Construct(WorkerConfigSO config)
        {
            Config = config;

            _stateSwitcher = new BaseStateSwitcher(new List<IState>()
            {
                new IdleWorkerState(this),
                new GoToExtractWorkerState(this),
                new ExtractWorkerState(this),
                new CarryWorkerState(this),
                new CompleteWorkerState(this, () => _workComplete.OnNext(Unit.Default))
            });
        }
        
        private void Awake()
        {
            _stateSwitcher.SwitchState<IdleWorkerState>();
        }

        public void SetState<TState>() where TState : IWorkerState
        {
            _stateSwitcher.SwitchState<TState>();
        }

        public IObservable<Unit> StartExtractProcess(IExtractable extractable, IDestination destination)
        {
            Work = extractable;
            Destination = destination;
            ExtractedInfo = new WorkExtractedInfo()
            {
                ResourceType = extractable.Info.gameResourceType, 
                ExtractValue = 0
            };
            SetState<GoToExtractWorkerState>();
            return _workComplete.AsObservable();
        }

        public IObservable<float> Extract(IExtractable extractable)
        {
            return Observable
                .Timer(TimeSpan.FromSeconds(Config.ExtractSpeed))
                .Select(value => extractable.Extract(Config.TakeAmount));
        }

        public void AddExtractionValue(float value)
        {
            if (ExtractedInfo != null)
            {
                ExtractedInfo.ExtractValue += value;
            }
            else
            {
                Debug.LogWarning("Поле ExtractedInfo не задано!");
            }
           
        }
    }
}