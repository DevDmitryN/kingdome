using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.WorkerAcceptor
{
    public class WorkerAcceptorFactory : IWorkerAcceptorFactory
    {
        [Inject] private DiContainer _diContainer;
        
        public IWorkerAcceptor Create(BuildingType buildingType, Vector3 position)
        {
            switch(buildingType)
            {
                case BuildingType.ResourceCollection:
                    return CreateResourceWorkerAcceptor(position);
                default:
                    return _diContainer.Instantiate<EmptyWorkerAcceptor>();
            }
        }

        private IWorkerAcceptor CreateResourceWorkerAcceptor(Vector3 position)
        {
            return _diContainer.Instantiate<ResourceWorkerAcceptor>(new List<object>() { position });
        }
    }
}