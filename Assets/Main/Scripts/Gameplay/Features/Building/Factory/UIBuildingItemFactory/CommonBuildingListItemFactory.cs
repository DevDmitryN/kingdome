using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building.Factory
{
    public class CommonBuildingListItemFactory : IBuildingListItemFactory
    {
        [Inject] private BuildingUIListItem _prefab;
        [Inject] private CommonBuildConfig _commonConfig;
        [Inject] private DiContainer _container;
        
        public BuildingUIListItem Create(Transform parent, BuildingConfig config)
        {
            return _container.InstantiatePrefabForComponent<BuildingUIListItem>(
                _prefab, 
                parent, 
                new object[] { _commonConfig, config}
                );
        }
    }
}