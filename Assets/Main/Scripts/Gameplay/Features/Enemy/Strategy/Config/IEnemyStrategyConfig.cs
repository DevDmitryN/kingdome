using Main.Scripts.Gameplay.Features.Enemy.Enums;

namespace Main.Scripts.Gameplay.Features.Enemy.Config
{
    public interface IEnemyStrategyConfig
    {
        EnemyStrategyType Type { get; }
    }
}