using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Factory
{
    public interface IBuildingListItemFactory
    {
        BuildingUIListItem Create(Transform parent, BuildingConfig config);
    }
}