using Main.Scripts.Gameplay.Features.Enemy.Models;

namespace Main.Scripts.Gameplay.Features.EnemyAcceptor
{
    public interface IEnemyAcceptor
    {
        void Accept(IEnemy enemy);
    }
}