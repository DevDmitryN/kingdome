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
    public class ResourceController : IDisposable
    {
        [Inject(Id = SpawnerType.GoldMine)]
        private ISpawner<ResourceGO> _goldMineSpawner;
        [Inject(Id = SpawnerType.Wood)]
        private ISpawner<ResourceGO> _woodSpawner;
        
        private readonly ResourceControllerConfig _config;
        private readonly Dictionary<ResourceType, List<ResourceGO>> _resources = new ();
        private Subject<Unit> _onDestroy = new();
        
        public ResourceController(ResourceControllerConfig config)
        {
            _config = config;
        }

        private ISpawner<ResourceGO> GetSpawner(ResourceType resourceType)
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

        private ResourceGO Spawn(ResourceType resourceType)
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
                var targetResources = new List<ResourceGO>();
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