﻿using System;
using UniRx;
using UnityEngine;

namespace Gameplay.Worker.WorkerStates
{
    public class ExtractWorkerState : IWorkerState
    {
        private readonly WorkerGO _worker;

        public ExtractWorkerState(WorkerGO worker)
        {
            _worker = worker;
        }
        
        public void Enter()
        {
            _worker.Work.DoWork(_worker)
                .Subscribe(value =>
                {
                    _worker.AddExtractionValue(value);
                    _worker.SetState<CarryWorkerState>();
                });
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
            
        }
    }
}