using System;
using Gameplay.Worker;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Worker.Models
{
    public interface IWorkable
    {
        Transform Transform { get; }
        bool IsEnded { get; }
        IObservable<float> DoWork(IWorker worker);
    }
}