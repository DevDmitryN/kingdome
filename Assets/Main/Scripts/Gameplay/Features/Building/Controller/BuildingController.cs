

using System.Collections.Generic;
using System.Linq;
using Extensions.Spawner;
using Main.Scripts.Gameplay.Features.Building.Factory;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.Models.Events;
using Main.Scripts.Gameplay.Installers.Tokens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingController
    {
        [Inject(Id = SpawnerType.BuildingPreview)] private ISpawner<BuildingPreviewMono> _previewSpawner;
        [Inject] private BuildingListConfig _buildingListConfig;
        [Inject] private IBuildingFactory _buildingFactory;
        [Inject] private BuildProcess _builderProcess;
        [Inject] private GameResourceController _resourceController;

        private List<BuildingMono> _buildings = new ();

        public void Init() 
        {
            var buildOnStartup = _buildingListConfig.BuildngConfigs
                .Where(v => v.CreateOnStartup)
                .ToList();

            foreach (var item in buildOnStartup)
            {
                Build(item.StartupBuildingConfig.StartPosition, item);
            }
        }

        public void StartBuilding(BuildingConfig buildingConfig) 
        {
            var buildingPreview = _previewSpawner.Spawn(Vector2.zero, new List<object>() { buildingConfig });
            
            _builderProcess.StartProcess(buildingPreview)
                .First()
                .Subscribe(result =>
                {
                    Object.Destroy(buildingPreview.gameObject);
                    Build(result.Position, buildingConfig);
                });
        }

        private void Build(Vector3 position, BuildingConfig config)
        {
            foreach (var condition in config.BuildResourceConditions)
            {
                _resourceController.ReduceResource(
                    new ReduceResourceParams() {
                        Type = condition.ResourceType,
                        Value = condition.RequiredValue
                    }
                );
            }
            
            var item = _buildingFactory.Create(position, config);
            _buildings.Add(item);
        }

        public List<BuildingMono> GetBuildingByType(BuildingType type) 
        {
            return _buildings.Where(v => v.Config.Type == type).ToList();
        }
    }
}