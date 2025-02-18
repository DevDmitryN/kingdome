using System;
using Gameplay.GoldMine;
using UniRx;

namespace Gameplay.Worker
{
    public interface IWorker
    {
        IObservable<float> Extract(IExtractable extractable);
    }
}