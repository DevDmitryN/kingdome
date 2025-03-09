using Extensions.Spawner;
using Extensions.Spawner.Mono;
using Gameplay.Entities.Castle;
using Gameplay.GoldMine.Config;
using Gameplay.Worker;
using Main.Scripts.Gameplay.Core.Service.Input;
using Main.Scripts.Gameplay.Features.ResourceContainer.Config;
using Main.Scripts.Gameplay.Features.ResourceContainer.Controller;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using Main.Scripts.Gameplay.Features.Worker.Config;
using Main.Scripts.Gameplay.Features.Worker.Controller;
using Main.Scripts.Gameplay.Installers.Tokens;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using CameraType = Main.Scripts.Gameplay.Installers.Tokens.CameraType;

namespace Main.Scripts.Gameplay.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Header("General")] 
        [SerializeField] private Camera _mainCamera;
        
        [Header("Resource containers")]
        [FormerlySerializedAs("extractResourceGo")] [FormerlySerializedAs("resourceGo")] [FormerlySerializedAs("_goldMineGo")] [SerializeField] private ResourceContainerGO resourceContainerGo;
        [SerializeField] private Transform _goldMineFolder;
        [SerializeField] private ExtractableSO _goldMineConfig;
        [SerializeField] private ExtractableSO _woodConfig;
        [FormerlySerializedAs("resourceControllerConfig")] [FormerlySerializedAs("_goldMineControllerConfig")] [SerializeField] private ResourceContainerControllerConfig resourceContainerControllerConfig;
        
        [Header("Worker")]
        [SerializeField] private WorkerGO _workerGo;
        [SerializeField] private Transform _workerFolder;
        [SerializeField] private WorkerConfigSO workerConfig;
        [SerializeField] private WorkerControllerConfig _workerControllerConfig;
        
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>()
                .WithId(CameraType.Main)
                .FromInstance(_mainCamera)
                .AsSingle();

            Container.Bind<IInputService>()
                .To<DesktopInputService>()
                .AsSingle();
            
            Container.Bind<ResourceContainerController>().AsSingle()
                .WithArguments(resourceContainerControllerConfig);
            Container.Bind<WorkerController>().AsSingle()
                .WithArguments(_workerControllerConfig);
            
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