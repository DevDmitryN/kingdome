using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public class DefaultStrategy : IBuildStrategy
    {

        private BuildingMono _building;

        public void ApplyTo(BuildingMono building)
        {
            _building = building;

            Debug.Log("Default стратегия работает");
        }

    }
}