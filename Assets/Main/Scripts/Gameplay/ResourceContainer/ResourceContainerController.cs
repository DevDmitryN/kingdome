using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Extensions;
using Extensions.Spawner;
using Gameplay.GoldMine.Config;
using Gameplay.Installers.Tokens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.GoldMine
{
    public class ResourceContainerController : IDisposable
    {
        [Inject(Id = SpawnerType.GoldMine)]
        private ISpawner<ResourceContainerGO> _goldMineSpawner;
        [Inject(Id = SpawnerType.Wood)]
        private ISpawner<ResourceContainerGO> _woodSpawner;
        
        private readonly ResourceContainerControllerConfig _config;
        private readonly Dictionary<ResourceType, List<ResourceContainerGO>> _resources = new ();
        private Subject<Unit> _onDestroy = new();
        
        public ResourceContainerController(ResourceContainerControllerConfig config)
        {
            _config = config;
        }

        private ISpawner<ResourceContainerGO> GetSpawner(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Gold:
                    return _goldMineSpawner;
                case ResourceType.Wood:
                    return _woodSpawner;
                default:
                    throw new Exception($"Свапнер для типа {resourceType} не найден");
            }
        }

        private ResourceContainerGO Spawn(ResourceType resourceType)
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,_config.MaxRadiusSpawn);
            var spawner = GetSpawner(resourceType);
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
                var resourceInitConfig = _config.GetSpawnConfig(spawnConfig.ResourceType);
                var targetResources = new List<ResourceContainerGO>();
                for (int i = 0; i < resourceInitConfig.InitAmount; i++)
                {
                    targetResources.Add(Spawn(spawnConfig.ResourceType));
                }
                _resources.Add(spawnConfig.ResourceType, targetResources);
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

        public List<IExtractable> GetResources(ResourceType resourceType)
        {
            return _resources[resourceType]
                .Where(v => v.Info.ResourceType == resourceType)
                .Select(v => (IExtractable) v)
                .ToList();
        }
        
    }
}