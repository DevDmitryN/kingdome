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
            var distance = Vector3.Distance(_worker.Acceptor.Position, _worker.transform.position);
            var duration = distance / _worker.Config.Speed;
            _worker.transform.DOMove(_worker.Acceptor.Position, duration)
                .OnComplete(() =>
                {
                    _worker.Acceptor.AcceptWorker(_worker);
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