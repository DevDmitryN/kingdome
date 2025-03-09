using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    public class CastleStrategy : IBuildStrategy, ICollectResourceStrategy
    {
        public Transform Transform => throw new System.NotImplementedException();

        public void AcceptWorker(IWorker worker)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyTo(BuildingMono building)
        {
            throw new System.NotImplementedException();
        }

        public void SetConfig(IBuildingStrategyConfig config)
        {
            throw new System.NotImplementedException();
        }
    }
}