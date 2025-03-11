using Main.Scripts.Gameplay.Features.Enemy.Enums;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Enemy.Config
{
    [CreateAssetMenu(fileName = "Attack Castle Strategy", menuName = "Enemy/Attack Castle Strategy", order = 0)]
    public class AttackCastleStrategyConfig : EnemyStrategyConfig
    {
        public override EnemyStrategyType Type => EnemyStrategyType.AttackCastle;
        public float MoveSpeed;
    }
}