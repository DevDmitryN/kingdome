using System.Collections.Generic;
using Extensions.Spawner;
using Main.Scripts.Gameplay.Features.BuildingStrategy;
using Main.Scripts.Gameplay.Features.WorkerAcceptor;
using Main.Scripts.Gameplay.Installers.Tokens;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building.Factory
{
    public class BuildingFactory : IBuildingFactory
    {
        [Inject(Id = SpawnerType.Building)] private ISpawner<BuildingMono> _spawner;
        [Inject] private IWorkerAcceptorFactory _workerAcceptorFactory;
        [Inject] private IBuildingStrategyFactory _strategyFactory;
        
        public BuildingMono Create(Vector3 position, BuildingConfig config)
        {
            var acceptor = _workerAcceptorFactory.Create(config.Type, position);
            var strategy = _strategyFactory.Create(config.strategySo);
            var building = _spawner.Spawn(position, new List<object>() { config, acceptor, strategy });
            //strategy.ApplyTo(building);
            return building;
        }

        
    }
}