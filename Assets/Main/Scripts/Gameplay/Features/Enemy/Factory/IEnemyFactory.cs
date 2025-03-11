using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Enemy.Factory
{
    public interface IEnemyFactory
    {
        EnemyMono Create(Vector3 position, EnemyUnitConfig config);
    }
}