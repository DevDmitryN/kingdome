using System;
using Extensions.Spawner;
using Extensions.Spawner.Mono;
using Gameplay.Entities.Castle;
using Gameplay.GoldMine;
using Gameplay.GoldMine.Config;
using Gameplay.Installers.Tokens;
using Gameplay.Worker;
using Gameplay.Worker.Config;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GoldMineGO _goldMineGo;
        [SerializeField] private Transform _goldMineFolder;
        [SerializeField] private ExtractableSO _goldMineConfig;
        [SerializeField] private GoldMineControllerConfig _goldMineControllerConfig;
        
        [SerializeField] private WorkerGO _workerGo;
        [SerializeField] private Transform _workerFolder;
        [SerializeField] private WorkerConfigSO workerConfig;
        [SerializeField] private WorkerControllerConfig _workerControllerConfig;

        [SerializeField] private CastleGO _castle;
        
        public override void InstallBindings()
        {
            Container.Bind<GoldMineController>().AsSingle()
                .WithArguments(_goldMineControllerConfig);
            Container.Bind<WorkerController>().AsSingle()
                .WithArguments(_workerControllerConfig, _castle);
            
            Container.Bind<ISpawner<GoldMineGO>>()
                .WithId(SpawnerType.GoldMine)
                .To<DiMonoSpawner<GoldMineGO>>()
                .AsSingle()
                .WithArguments(_goldMineGo, _goldMineFolder);
            Container.Bind<ISpawner<WorkerGO>>()
                .WithId(SpawnerType.Worker)
                .To<DiMonoSpawner<WorkerGO>>()
                .AsSingle()
                .WithArguments(_workerGo, _workerFolder);

            Container.Bind<ExtractableSO>()
                .FromInstance(_goldMineConfig)
                .AsSingle();
            
            Container.Bind<WorkerConfigSO>()
                .FromInstance(workerConfig)
                .AsSingle();
        }
    }
}