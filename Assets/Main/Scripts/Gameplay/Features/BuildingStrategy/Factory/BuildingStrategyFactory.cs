using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Building;
using Zenject;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public class BuildingStrategyFactory : IBuildingStrategyFactory
    {
        [Inject] private DiContainer _diContainer;

        public IBuildStrategy Create(IBuildingStrategyConfig config) 
        {
            switch(config.ConfigStrategyType)
            {
                case StrategyType.Castle:
                    return _diContainer.Instantiate<CastleStrategy>(new List<object>() { config });
                case StrategyType.AttackInRadius:
                    return _diContainer.Instantiate<AttackDistanceStrategy>(new List<object>() { config });
                default:
                    return _diContainer.Instantiate<DefaultStrategy>();
            }
        }
    }
}