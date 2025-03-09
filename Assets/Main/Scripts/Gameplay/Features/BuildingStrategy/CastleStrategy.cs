using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public class CastleStrategy : IBuildStrategy
    {
        [Inject] private IBuildingStrategyConfig _config;

        private BuildingMono _building;

        public void ApplyTo(BuildingMono building)
        {
            _building = building;

            Debug.Log("Castle стратегия работает");
        }

    }
}