

using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Enemy.Models
{
    public interface IEnemy
    {
        Vector3 Position { get; }
        bool IsDead { get; }
        void TakeDamage(float amount);
    }
}