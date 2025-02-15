using System;
using UniRx;


namespace Gameplay.Worker.Commands
{
    public interface IWorkerCommand
    {
        IObservable<Unit> Execute(WorkerGO worker);
    }
}