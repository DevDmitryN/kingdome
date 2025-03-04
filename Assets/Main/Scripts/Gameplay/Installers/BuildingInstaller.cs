using Extensions.Spawner;
using Extensions.Spawner.Mono;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.Building.Factory;
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
        [Header("Common")]
        public BuildingListConfig buildingListConfig;
        public CommonBuildConfig CommonBuildConfig;
        [Header("UI")]
        public BuildingUIList UiBildingList;
        public BuildingUIListItem UiBuildingPrefab;
        [Header("After Build")]
        public BuildingMono BuildingPrefab;
        public Transform BuildingsFolder;
        [Header("Build process")]
        public BuildingPreviewMono BuildingPreviewPrefab;
        public Transform BuildingsPreviewFolder;
        // public BuildProcessMono BuildProcessScript;
       
        
        public override void InstallBindings()
        {
            Container.Bind<ISpawner<BuildingMono>>()
                .WithId(SpawnerType.Building)
                .To<SimpleDiSpawner<BuildingMono>>()
                .AsCached()
                .WithArguments(BuildingPrefab, BuildingsFolder);
            
            Container.Bind<ISpawner<BuildingPreviewMono>>()
                .WithId(SpawnerType.BuildingPreview)
                .To<SimpleDiSpawner<BuildingPreviewMono>>()
                .AsCached()
                .WithArguments(BuildingPreviewPrefab, BuildingsPreviewFolder);

            Container.Bind<BuildingListConfig>()
                .FromInstance(buildingListConfig)
                .AsSingle();
            
            Container.Bind<CommonBuildConfig>()
                .FromInstance(CommonBuildConfig)
                .AsSingle();
            
            Container.Bind<BuildingMono>()
                .FromInstance(BuildingPrefab)
                .AsSingle();
            
            Container.Bind<BuildingPreviewMono>()
                .FromInstance(BuildingPreviewPrefab)
                .AsSingle();
        
            Container.Bind<BuildingUIListItem>()
                .FromInstance(UiBuildingPrefab)
                .AsSingle();

            Container.Bind<IBuildingListItemFactory>()
                .To<CommonBuildingListItemFactory>()
                .AsSingle();
            
            Container.Bind<BuildingUIList>()
                .FromInstance(UiBildingList)
                .AsSingle();

            Container.Bind<BuildingController>()
                .AsSingle();

            Container.Bind(typeof(ITickable), typeof(BuildProcess))
                .To<BuildProcess>()
                .AsSingle();
        }
    }
}