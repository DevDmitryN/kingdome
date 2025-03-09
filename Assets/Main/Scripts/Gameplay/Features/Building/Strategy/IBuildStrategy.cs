namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    public interface IBuildStrategy 
    {
        void SetConfig(IBuildingStrategyConfig config);
        void ApplyTo(BuildingMono building);
    }
}