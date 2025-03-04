

using System.Collections.Generic;
using Extensions.Spawner;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Installers.Tokens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingController
    {
        [Inject(Id = SpawnerType.BuildingPreview)] private ISpawner<BuildingPreviewMono> _previewSpawner;
        [Inject(Id = SpawnerType.Building)] private ISpawner<BuildingMono> _buildingSpawner;
        [Inject] private BuildProcess _builderProcess;
        [Inject] private GameResourceController _resourceController;

        public void StartBuilding(BuildingConfig buildingConfig) 
        {
            var buildingPreview = _previewSpawner.Spawn(Vector2.zero, new List<object>() { buildingConfig });
            
            _builderProcess.StartProcess(buildingPreview)
                .First()
                .Subscribe(result =>
                {
                    Object.Destroy(buildingPreview.gameObject);
                    Build(result, buildingConfig);
                });
        }

        private void Build(BuildProcessResult buildProcessResult, BuildingConfig config)
        {
            _buildingSpawner.Spawn(buildProcessResult.Position, new List<object>() { config });
            foreach (var condition in config.BuildResourceConditions)
            {
                _resourceController.ReduceResource(new ()
                {
                    Type = condition.ResourceType,
                    Value = condition.RequiredValue,
                });
            }
        }
    }
}