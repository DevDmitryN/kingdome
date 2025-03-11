using System.Linq;
using DG.Tweening;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.Strategy
{
    public class AttackCastleEnemyStrategy : IEnemyStrategy
    {
        [Inject] private BuildingController _buildingController;
        [Inject] private AttackCastleStrategyConfig _config;
        private EnemyMono _enemy;
        
        public void ApplyTo(EnemyMono enemy)
        {
            _enemy = enemy;

            var castle = _buildingController
                .GetBuildingByType(BuildingType.ResourceCollection)
                .First();

            var duration = Vector3.Distance(enemy.transform.position, castle.transform.position) / _config.MoveSpeed;

         
            enemy.transform.DOMove(castle.transform.position, duration)
                .OnComplete(() =>
                {
                 
                });
        }
    }
}