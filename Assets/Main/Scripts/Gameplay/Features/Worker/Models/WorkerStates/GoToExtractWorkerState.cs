﻿using DG.Tweening;
using UnityEngine;

namespace Gameplay.Worker.WorkerStates
{
    public class GoToExtractWorkerState : IWorkerState
    {
        private readonly WorkerGO _worker;

        public GoToExtractWorkerState(WorkerGO worker)
        {
            _worker = worker;
        }
        
        public void Enter()
        {
         
            var duration = Vector3.Distance(_worker.Work.Transform.position, _worker.transform.position) /
                           _worker.Config.Speed;
            _worker.transform.DOMove(_worker.Work.Transform.position, duration)
                .OnComplete(() =>
                {
                    _worker.SetState<ExtractWorkerState>();
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