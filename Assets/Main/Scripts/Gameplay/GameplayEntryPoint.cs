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
        private ResourceContainerController _resourceContainerController;
        private WorkerController _workerController;
        private GameResourceController _gameResourceController;
        private UIGameResourceList _uiGameResourceList;
        private BuildingUIList _buildingUIList;

        [Inject]
        public void Construct(
            ResourceContainerController resourceContainerController, 
            WorkerController workerController,
            GameResourceController gameResourceController,
            UIGameResourceList uiGameResourceList,
            BuildingUIList buildingUIList
            )
        {
            _resourceContainerController = resourceContainerController;
            _workerController = workerController;
            _gameResourceController = gameResourceController;
            _uiGameResourceList = uiGameResourceList;
            _buildingUIList = buildingUIList;
        
            _disposables.Add(_resourceContainerController);
            _disposables.Add(_workerController);
        }

        private void Start()
        {
            Debug.Log("Entry point");
            _resourceContainerController.Init();
            _workerController.Init();
            _gameResourceController.Init();
            _uiGameResourceList.Init();
            _buildingUIList.Init();
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
