using Main.Scripts.Gameplay.Features.Building;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public interface IBuildStrategy 
    {
        void ApplyTo(BuildingMono building);
    }
}