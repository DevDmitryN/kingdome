using System;
using Gameplay.Entities.Castle;
using Gameplay.Worker;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using UniRx;

namespace Main.Scripts.Gameplay.Features.Worker.Commands
{
    public class ExtractWorkerCommand : IWorkerCommand
    {
        private WorkerGO _workerGo;
        private readonly IExtractable _extractable;
        private readonly IDestination _destination;

        public ExtractWorkerCommand(IExtractable extractable, IDestination destination)
        {
            _extractable = extractable;
            _destination = destination;
        }

        public IObservable<Unit> Execute(WorkerGO workerGo)
        {
            _workerGo = workerGo;
            return _workerGo.StartExtractProcess(_extractable, _destination);
        }
    }
}