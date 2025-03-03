

using System.Collections.Generic;
using Extensions.Spawner;
using Main.Scripts.Gameplay.Installers.Tokens;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingController 
    {
        [Inject(Id = SpawnerType.Building)] private ISpawner<BuildingMono> _spawner;

        public void StartBuilding(BuildingConfig buildingConfig) 
        {
            _spawner.Spawn(Vector2.zero, new List<object>() { buildingConfig });
        }
    }
}