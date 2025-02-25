using System;
using System.Collections.Generic;
using Gameplay.GoldMine;
using Gameplay.Worker;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private readonly List<IDisposable> _disposables = new ();
    private ResourceContainerController _resourceContainerController;
    private WorkerController _workerController;
    

    [Inject]
    public void Construct(ResourceContainerController resourceContainerController, WorkerController workerController)
    {
        _resourceContainerController = resourceContainerController;
        _workerController = workerController;
        
        _disposables.Add(_resourceContainerController);
        _disposables.Add(_workerController);
    }

    private void Start()
    {
        Debug.Log("Entry point");
        _resourceContainerController.Init();
        _workerController.Init();
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
