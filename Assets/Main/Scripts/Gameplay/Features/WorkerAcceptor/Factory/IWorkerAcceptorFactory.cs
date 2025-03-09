using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.WorkerAcceptor
{
    public interface IWorkerAcceptorFactory
    {
        IWorkerAcceptor Create(BuildingType buildingType, Vector3 position);
    }
}