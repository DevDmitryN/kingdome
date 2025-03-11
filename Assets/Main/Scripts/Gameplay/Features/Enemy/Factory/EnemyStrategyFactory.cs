using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Enums;
using Main.Scripts.Gameplay.Features.Enemy.Strategy;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.Factory
{
    public class EnemyStrategyFactory : IEnemyStrategyFactory
    {
        [Inject] private DiContainer _diContainer;
        
        public IEnemyStrategy Create(IEnemyStrategyConfig config)
        {
            switch (config.Type)
            {
                case EnemyStrategyType.AttackCastle:
                    return _diContainer.Instantiate<AttackCastleEnemyStrategy>(new List<object>() { config });
                default:
                    return _diContainer.Instantiate<DefaultEnemyStrategy>();
            }
        }
    }
}