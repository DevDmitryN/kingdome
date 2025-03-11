using Main.Scripts.Gameplay.Features.Enemy.Models;

namespace Main.Scripts.Gameplay.Features.EnemyAcceptor
{
    public class DefaultDamageEnemyAcceptor : IEnemyAcceptor
    {
        private readonly float _damage = 1;

        public DefaultDamageEnemyAcceptor(float damage)
        {
            _damage = damage;
        }

        public void Accept(IEnemy enemy)
        {
            enemy.TakeDamage(_damage);
        }
    }
}