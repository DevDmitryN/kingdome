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
        [FormerlySerializedAs("_goldMineGo")] [SerializeField] private ResourceGO resourceGo;
        [SerializeField] private Transform _goldMineFolder;
        [SerializeField] private ExtractableSO _goldMineConfig;
        [SerializeField] private ExtractableSO _woodConfig;
        [FormerlySerializedAs("_goldMineControllerConfig")] [SerializeField] private ResourceControllerConfig resourceControllerConfig;
        
        [SerializeField] private WorkerGO _workerGo;
        [SerializeField] private Transform _workerFolder;
        [SerializeField] private WorkerConfigSO workerConfig;
        [SerializeField] private WorkerControllerConfig _workerControllerConfig;

        [SerializeField] private CastleGO _castle;
        
        public override void InstallBindings()
        {
            Container.Bind<ResourceController>().AsSingle()
                .WithArguments(resourceControllerConfig);
            Container.Bind<WorkerController>().AsSingle()
                .WithArguments(_workerControllerConfig, _castle);
            
            Container.Bind<ISpawner<ResourceGO>>()
                .WithId(SpawnerType.GoldMine)
                .To<DiMonoSpawner<ResourceGO, ExtractableSO>>()
                .AsCached()
                .WithArguments(resourceGo, _goldMineFolder, _goldMineConfig);
            
            Container.Bind<ISpawner<ResourceGO>>()
                .WithId(SpawnerType.Wood)
                .To<DiMonoSpawner<ResourceGO, ExtractableSO>>()
                .AsCached()
                .WithArguments(resourceGo, _goldMineFolder, _woodConfig);
            
            Container.Bind<ISpawner<WorkerGO>>()
                .WithId(SpawnerType.Worker)
                .To<DiMonoSpawner<WorkerGO, WorkerConfigSO>>()
                .AsSingle()
                .WithArguments(_workerGo, _workerFolder, workerConfig);

            Container.Bind<ExtractableSO>()
                .FromInstance(_goldMineConfig)
                .AsSingle();
            
            Container.Bind<WorkerConfigSO>()
                .FromInstance(workerConfig)
                .AsSingle();
        }
    }
}