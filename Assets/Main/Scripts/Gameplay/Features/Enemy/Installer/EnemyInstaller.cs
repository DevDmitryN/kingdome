using System;
using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Factory;
using Main.Scripts.Gameplay.Features.Enemy.Models;
using Main.Scripts.Gameplay.Features.Enemy.Strategy;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.Installer
{
    [Serializable]
    public class EnemyConfigs
    {
        public List<EnemyUnitConfig> EnemyUnitConfigs;
    }
    
    public class EnemyInstaller : MonoInstaller
    {
        public EnemyMono EnemyPrefab;
        public Transform EnemyFolder;
        public EnemyConfigs EnemyConfigs;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyMono>()
                .FromInstance(EnemyPrefab)
                .AsSingle();
            Container.Bind<EnemyConfigs>()
                .FromInstance(EnemyConfigs)
                .AsSingle();

            Container.Bind<IEnemyStrategyFactory>()
                .To<EnemyStrategyFactory>()
                .AsSingle();
            
            Container.Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle()
                .WithArguments(EnemyFolder);
        }
    }
}