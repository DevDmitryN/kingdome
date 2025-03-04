

using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Factory
{
    public interface IBuildingFactory
    {
        BuildingMono Create(Vector3 position, BuildingConfig config);
    }
}