using UnityEngine;

namespace Gameplay.Worker.WorkerStates
{
    public class IdleWorkerState : IWorkerState
    {
        private readonly WorkerGO _worker;

        public IdleWorkerState(WorkerGO worker)
        {
            _worker = worker;
        }
        
        public void Enter()
        {
          
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
         
        }
    }
}