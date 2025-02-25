using System;
using Gameplay.Worker;
using UniRx;
using UnityEngine;

namespace Gameplay.GoldMine
{
    public interface IWorkable
    {
        Transform Transform { get; }
        bool IsEnded { get; }
        IObservable<float> DoWork(IWorker worker);
    }
}