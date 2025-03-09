using Main.Scripts.Gameplay.Features.Building;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public interface IBuildingStrategyFactory
    {
        IBuildStrategy Create(IBuildingStrategyConfig config);
    }
}