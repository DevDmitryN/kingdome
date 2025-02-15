using System;
using System.Collections.Generic;
using Gameplay.GoldMine;
using Gameplay.Worker;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private readonly List<IDisposable> _disposables = new ();
    private GoldMineController _goldMineController;
    private WorkerController _workerController;
    

    [Inject]
    public void Construct(GoldMineController goldMineController, WorkerController workerController)
    {
        _goldMineController = goldMineController;
        _workerController = workerController;
        
        _disposables.Add(_goldMineController);
        _disposables.Add(_workerController);
    }

    private void Start()
    {
        Debug.Log("Entry point");
        _goldMineController.Init();
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
