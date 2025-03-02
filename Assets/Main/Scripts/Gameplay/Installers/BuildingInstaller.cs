using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using UnityEngine.Serialization;
using Zenject;

namespace Main.Scripts.Gameplay.Installers
{
    public class BuildingInstaller : MonoInstaller
    {
        public BuildingUIList UiBildingList;
        public BuildingUIListItem UiBuildingPrefab;
        public BuildingListConfig buildingListConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<BuildingListConfig>()
                .FromInstance(buildingListConfig)
                .AsSingle();
            
        
            Container.Bind<BuildingUIListItem>()
                .FromInstance(UiBuildingPrefab)
                .AsSingle();
            
            Container.Bind<BuildingUIList>()
                .FromInstance(UiBildingList)
                .AsSingle();
        }
    }
}