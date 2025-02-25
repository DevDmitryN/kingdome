using System;
using Gameplay.Worker;
using UniRx;

namespace Main.Scripts.Gameplay.Features.Worker.Commands
{
    public interface IWorkerCommand
    {
        IObservable<Unit> Execute(WorkerGO worker);
    }
}