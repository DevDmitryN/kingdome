using System.Collections.Generic;
using Extensions.Spawner;
using Main.Scripts.Gameplay.Installers.Tokens;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building.Factory
{
    public class BuildingFactory : IBuildingFactory
    {
        [Inject(Id = SpawnerType.Building)] private ISpawner<BuildingMono> _spawner;
        // TODO стратегии
        
        public BuildingMono Create(Vector3 position, BuildingConfig config)
        {
            var item = _spawner.Spawn(position, new List<object>() { config });

            return item;
        }
    }
}