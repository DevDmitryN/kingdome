using Main.Scripts.Gameplay.Core.Cooldown;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.BuildingStrategy.TowerAttack;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using Main.Scripts.Gameplay.Features.EnemyAcceptor;
using UniRx;
using UniRx.Triggers;
using Zenject;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public class AttackDistanceStrategy : IBuildStrategy
    {
        [Inject] private AttackInRadiusBuildStrategySO _config;
        private BuildingMono _building;
        private TowerAttackMono _towerAttack;
        private IEnemyAcceptor _enemyAcceptor;
        private SingleCooldown _cooldown;

        public void ApplyTo(BuildingMono building)
        {
            _building = building;
            Init();
        }

        private void Init()
        {
            _cooldown = new SingleCooldown().SetCooldown(_config.AttackCooldown);
            _enemyAcceptor = new DefaultDamageEnemyAcceptor(_config.Damage);
            
            _towerAttack = Object.Instantiate(_config.TowerAttackPrefab, _building.transform);
            _towerAttack._attackCollider.radius = _config.AttackRadius;
            _towerAttack._attackCollider
                .OnTriggerStay2DAsObservable()
                .Subscribe(OnTriggerStay);
        }

        private void OnTriggerStay(Collider2D collider)
        {
            Debug.Log("Trigger work");
            Debug.Log(collider);
            if (collider.TryGetComponent<IEnemy>(out var enemy))
            {
                if (_cooldown.Ended)
                {
                    _towerAttack.TriggerAttack(new TowerAttackProps()
                    {
                        EnemyAcceptor = _enemyAcceptor,
                        Enemy = enemy,
                        BulletSpeed = 8,
                    });
                    _cooldown.Reset();
                }
               
            }
        }
    }
}