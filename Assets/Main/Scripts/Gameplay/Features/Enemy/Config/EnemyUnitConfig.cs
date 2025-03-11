using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Enemy.Config
{
    [CreateAssetMenu(fileName = "Enemy unit config", menuName = "Enemy/Enemy unit config", order = 0)]
    public class EnemyUnitConfig : ScriptableObject
    {
        public EnemyStrategyConfig Strategy;
    }
}