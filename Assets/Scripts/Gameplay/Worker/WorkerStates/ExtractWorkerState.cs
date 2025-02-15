using System;
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
            _worker.Extractable.Extract(_worker.Config.TakeAmount, _worker.Config.ExtractSpeed)
                .Subscribe(value =>
                {
                    Debug.Log($"Добыто {value}");
                    _worker.SetState(typeof(CarryWorkerState));
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