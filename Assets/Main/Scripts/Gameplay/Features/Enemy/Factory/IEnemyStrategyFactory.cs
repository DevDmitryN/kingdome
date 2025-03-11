using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Strategy;

namespace Main.Scripts.Gameplay.Features.Enemy.Factory
{
    public interface IEnemyStrategyFactory
    {
        IEnemyStrategy Create(IEnemyStrategyConfig config);
    }
}