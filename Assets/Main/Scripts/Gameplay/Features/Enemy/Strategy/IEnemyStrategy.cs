using Main.Scripts.Gameplay.Features.Enemy.Models;

namespace Main.Scripts.Gameplay.Features.Enemy.Strategy
{
    public interface IEnemyStrategy
    {
        void ApplyTo(EnemyMono enemy);
    }
}