using System;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Strategy;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Main.Scripts.Gameplay.Features.Enemy.Models
{
    public class EnemyMono : MonoBehaviour, IEnemy
    {
        [Inject] private EnemyUnitConfig _config;
        [Inject] private IEnemyStrategy _strategy;

        [SerializeField] private BoxCollider2D _collider;

        public float Health;
        public Vector3 Position => transform.position;
        public bool IsDead => Health <= 0 || gameObject == null;
        
        private void Awake()
        {
            Health = _config.Health;
            _collider.size = _config.ColliderSize;
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (IsDead)
                Destroy(gameObject);
        }
    }
}