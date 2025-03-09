using Main.Scripts.Gameplay.Features.Building;
using Zenject;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public class AttackDistanceStrategy : IBuildStrategy
    {
        [Inject] private IBuildingStrategyConfig _config;

        private BuildingMono _building;

        public void ApplyTo(BuildingMono building)
        {
            _building = building;
        }

        public void SetConfig(IBuildingStrategyConfig config)
        {
            throw new System.NotImplementedException();
        }
    }
}