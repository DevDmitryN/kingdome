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
        [FormerlySerializedAs("extractResourceGo")] [FormerlySerializedAs("resourceGo")] [FormerlySerializedAs("_goldMineGo")] [SerializeField] private ResourceContainerGO resourceContainerGo;
        [SerializeField] private Transform _goldMineFolder;
        [SerializeField] private ExtractableSO _goldMineConfig;
        [SerializeField] private ExtractableSO _woodConfig;
        [FormerlySerializedAs("resourceControllerConfig")] [FormerlySerializedAs("_goldMineControllerConfig")] [SerializeField] private ResourceContainerControllerConfig resourceContainerControllerConfig;
        
        [SerializeField] private WorkerGO _workerGo;
        [SerializeField] private Transform _workerFolder;
        [SerializeField] private WorkerConfigSO workerConfig;
        [SerializeField] private WorkerControllerConfig _workerControllerConfig;

        [SerializeField] private CastleGO _castle;
        
        public override void InstallBindings()
        {
            Container.Bind<ResourceContainerController>().AsSingle()
                .WithArguments(resourceContainerControllerConfig);
            Container.Bind<WorkerController>().AsSingle()
                .WithArguments(_workerControllerConfig, _castle);
            
            Container.Bind<ISpawner<ResourceContainerGO>>()
                .WithId(SpawnerType.GoldMine)
                .To<DiMonoSpawner<ResourceContainerGO, ExtractableSO>>()
                .AsCached()
                .WithArguments(resourceContainerGo, _goldMineFolder, _goldMineConfig);
            
            Container.Bind<ISpawner<ResourceContainerGO>>()
                .WithId(SpawnerType.Wood)
                .To<DiMonoSpawner<ResourceContainerGO, ExtractableSO>>()
                .AsCached()
                .WithArguments(resourceContainerGo, _goldMineFolder, _woodConfig);
            
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