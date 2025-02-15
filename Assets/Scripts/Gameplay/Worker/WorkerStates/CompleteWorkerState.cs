using System;
using UniRx;
using UnityEngine;

namespace Gameplay.Worker.WorkerStates
{
    public class CompleteWorkerState : IWorkerState
    {
        private readonly WorkerGO _worker;
        private readonly Action _callback;

        public CompleteWorkerState(WorkerGO worker, Action callback)
        {
            _worker = worker;
            _callback = callback;
        }
        
        public void Enter()
        {
            _callback.Invoke();
            _worker.SetState(typeof(IdleWorkerState));
        }

        public void Exit()
        {
         
        }

        public void Update()
        {
          
        }
    }
}