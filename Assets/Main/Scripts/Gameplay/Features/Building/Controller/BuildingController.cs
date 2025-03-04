

using System.Collections.Generic;
using Extensions.Spawner;
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
        [Inject] private BuildProcessMono _builderProcess;

        public void StartBuilding(BuildingConfig buildingConfig) 
        {
            var buildingPreview = _previewSpawner.Spawn(Vector2.zero, new List<object>() { buildingConfig });
            
            _builderProcess.StartProcess(buildingPreview)
                .First()
                .Subscribe(result =>
                {
                    Object.Destroy(buildingPreview.gameObject);
                    _buildingSpawner.Spawn(result.Position, new List<object>() { buildingConfig });
                });
        }
    }
}