using System;
using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using Main.Scripts.Gameplay.Features.ResourceContainer.Controller;
using Main.Scripts.Gameplay.Features.Worker.Controller;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private readonly List<IDisposable> _disposables = new ();
        [Inject] private ResourceContainerController _resourceContainerController;
        [Inject] private WorkerController _workerController;
        [Inject] private GameResourceController _gameResourceController;
        [Inject] private UIGameResourceList _uiGameResourceList;
        [Inject] private BuildingUIList _buildingUIList;
        [Inject] private BuildingController _buildingController;
        
        private void Start()
        {
            _buildingController.Init();
            _resourceContainerController.Init();
            _workerController.Init();
            _gameResourceController.Init();
            _uiGameResourceList.Init();
            _buildingUIList.Init();
           
            
            _disposables.Add(_resourceContainerController);
            _disposables.Add(_workerController);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
