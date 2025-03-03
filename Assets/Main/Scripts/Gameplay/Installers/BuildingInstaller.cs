using Extensions.Spawner;
using Extensions.Spawner.Mono;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using Main.Scripts.Gameplay.Installers.Tokens;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Main.Scripts.Gameplay.Installers
{
    public class BuildingInstaller : MonoInstaller
    {
        public BuildingUIList UiBildingList;
        public BuildingUIListItem UiBuildingPrefab;
        public BuildingMono BuildingPrefab;
        public Transform BuildingsFolder;
        public BuildingListConfig buildingListConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<ISpawner<BuildingMono>>()
                .WithId(SpawnerType.Building)
                .To<SimpleDiSpawner<BuildingMono>>()
                .AsCached()
                .WithArguments(BuildingPrefab, BuildingsFolder);

            Container.Bind<BuildingListConfig>()
                .FromInstance(buildingListConfig)
                .AsSingle();
            
            Container.Bind<BuildingMono>()
                .FromInstance(BuildingPrefab)
                .AsSingle();
        
            Container.Bind<BuildingUIListItem>()
                .FromInstance(UiBuildingPrefab)
                .AsSingle();
            
            Container.Bind<BuildingUIList>()
                .FromInstance(UiBildingList)
                .AsSingle();

            Container.Bind<BuildingController>()
                .AsSingle();

           
        }
    }
}