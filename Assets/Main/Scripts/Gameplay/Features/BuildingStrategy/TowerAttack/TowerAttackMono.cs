using System;
using DG.Tweening;
using Extensions.Pool;
using Main.Scripts.Gameplay.Core.Moving;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using Main.Scripts.Gameplay.Features.EnemyAcceptor;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy.TowerAttack
{
    public class TowerAttackProps
    {
        public IEnemy Enemy;
        public IEnemyAcceptor EnemyAcceptor;
        public float BulletSpeed;
    }
    
    public class TowerAttackMono : MonoBehaviour
    {
        private IObjectPool<TowerAttackBullet> _bulletPool;
        public TowerAttackBullet TowerBulletPrefab;
        public CircleCollider2D _attackCollider;

        private void Awake()
        {
            _bulletPool = new MonoPool<TowerAttackBullet>(TowerBulletPrefab, transform, 10);
            TowerBulletPrefab.gameObject.SetActive(false);
        }

        public void TriggerAttack(TowerAttackProps props)
        {
            var moving = new FixNotPhysicMoving(props.BulletSpeed, 0.1f);
            
            var bullet = _bulletPool.Get();
            bullet.transform.position = transform.position;
            bullet.FixedUpdateAsObservable()
                .TakeUntilDisable(bullet)
                .TakeUntilDisable(this)
                .Subscribe(_ =>
                {
                    if (props.Enemy.IsDead)
                    {
                        Debug.Log("Enemy null");
                        _bulletPool.Hide(bullet);
                        return;
                    }

                    bullet.transform.position = moving.Move(bullet.transform.position, props.Enemy.Position);
                    
                    if (moving.IsEnded)
                    {
                        props.EnemyAcceptor.Accept(props.Enemy);
                        _bulletPool.Hide(bullet);
                    }
                });
            // bullet.transform.DOMove()
        }
    }
}