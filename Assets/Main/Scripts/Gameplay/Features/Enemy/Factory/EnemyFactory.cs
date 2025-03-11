using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        [Inject] private IEnemyStrategyFactory _enemyStrategyFactory;
        [Inject] private EnemyMono _enemyPrefab;
        [Inject] private Transform _enemyFolder;
        [Inject] private DiContainer _diContainer;
        
        public EnemyMono Create(Vector3 position, EnemyUnitConfig config)
        {
            var strategy = _enemyStrategyFactory.Create(config.Strategy);
            var enemy = _diContainer.InstantiatePrefabForComponent<EnemyMono>(_enemyPrefab, _enemyFolder,
                new List<object>() { config, strategy });
            enemy.transform.position = position;
            strategy.ApplyTo(enemy);
            return enemy;
        }
    }
}