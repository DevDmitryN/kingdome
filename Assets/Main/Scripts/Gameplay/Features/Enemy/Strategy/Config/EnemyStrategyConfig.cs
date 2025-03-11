using Main.Scripts.Gameplay.Features.Enemy.Enums;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Enemy.Config
{
    [CreateAssetMenu(fileName = "Default Enemy strategy", menuName = "Enemy/Default Enemy strategy", order = 0)]
    public class EnemyStrategyConfig : ScriptableObject, IEnemyStrategyConfig
    {
        public virtual EnemyStrategyType Type => EnemyStrategyType.Default;
    }
}