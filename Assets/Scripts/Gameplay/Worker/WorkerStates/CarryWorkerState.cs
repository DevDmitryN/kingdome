using DG.Tweening;
using UnityEngine;

namespace Gameplay.Worker.WorkerStates
{
    /// <summary>
    /// Несет добытые ресурсы на ба                                                                                  
    /// </summary>
    public class CarryWorkerState : IWorkerState
    {
        private readonly WorkerGO _worker;

        public CarryWorkerState(WorkerGO worker)
        {
            _worker = worker;
        }
        
        public void Enter()
        {
            var duration = Vector3.Distance(_worker.Destination.Transform.position, _worker.transform.position) /
                           _worker.Config.Speed;
            _worker.transform.DOMove(_worker.Destination.Transform.position, duration)
                .OnComplete(() =>
                {
                    if (_worker.Work.IsEnded)
                    {
                        _worker.SetState<CompleteWorkerState>();
                    }
                    else
                    {
                        _worker.SetState<GoToExtractWorkerState>();
                    }
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