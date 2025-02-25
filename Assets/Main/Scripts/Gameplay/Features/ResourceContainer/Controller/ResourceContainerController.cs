using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Extensions;
using Extensions.Spawner;
using Gameplay.GoldMine;
using Gameplay.GoldMine.Config;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using Main.Scripts.Gameplay.Installers.Tokens;
using UniRx;
using Zenject;

namespace Main.Scripts.Gameplay.Features.ResourceContainer.Controller
{
    public class ResourceContainerController : IDisposable
    {
        [Inject(Id = SpawnerType.GoldMine)]
        private ISpawner<ResourceContainerGO> _goldMineSpawner;
        [Inject(Id = SpawnerType.Wood)]
        private ISpawner<ResourceContainerGO> _woodSpawner;
        
        private readonly ResourceContainerControllerConfig _config;
        private readonly Dictionary<GameResourceType, List<ResourceContainerGO>> _resources = new ();
        private Subject<Unit> _onDestroy = new();
        
        public ResourceContainerController(ResourceContainerControllerConfig config)
        {
            _config = config;
        }

        private ISpawner<ResourceContainerGO> GetSpawner(GameResourceType gameResourceType)
        {
            switch (gameResourceType)
            {
                case GameResourceType.Gold:
                    return _goldMineSpawner;
                case GameResourceType.Wood:
                    return _woodSpawner;
                default:
                    throw new Exception($"Свапнер для типа {gameResourceType} не найден");
            }
        }

        private ResourceContainerGO Spawn(GameResourceType gameResourceType)
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,_config.MaxRadiusSpawn);
            var spawner = GetSpawner(gameResourceType);
            var item = spawner.Spawn(position);
            item.OnEnded
                .First()
                .TakeUntil(_onDestroy)
                .Subscribe(value =>
                {
                    spawner.Hide(item);
                });
            return item;
        }

        private void InitResources()
        {
            foreach (var spawnConfig in _config.SpawnConfigs)
            {
                var resourceInitConfig = _config.GetSpawnConfig(spawnConfig.gameResourceType);
                var targetResources = new List<ResourceContainerGO>();
                for (int i = 0; i < resourceInitConfig.InitAmount; i++)
                {
                    targetResources.Add(Spawn(spawnConfig.gameResourceType));
                }
                _resources.Add(spawnConfig.gameResourceType, targetResources);
            }
        }
        
        public void Dispose()
        {
            _onDestroy.OnNext(Unit.Default);
            _onDestroy.OnCompleted();
            _onDestroy.Dispose();
        }

        public void Init()
        {
            InitResources();
        }

        public List<IExtractable> GetResources(GameResourceType gameResourceType)
        {
            return _resources[gameResourceType]
                .Where(v => v.Info.gameResourceType == gameResourceType)
                .Select(v => (IExtractable) v)
                .ToList();
        }
        
    }
}