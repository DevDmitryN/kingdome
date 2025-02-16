using System;
using System.Collections.Generic;
using Gameplay.GoldMine;
using Gameplay.Worker;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private readonly List<IDisposable> _disposables = new ();
    private ResourceController _resourceController;
    private WorkerController _workerController;
    

    [Inject]
    public void Construct(ResourceController resourceController, WorkerController workerController)
    {
        _resourceController = resourceController;
        _workerController = workerController;
        
        _disposables.Add(_resourceController);
        _disposables.Add(_workerController);
    }

    private void Start()
    {
        Debug.Log("Entry point");
        _resourceController.Init();
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
