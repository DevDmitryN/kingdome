using System;
using Gameplay.Entities.Castle;
using Gameplay.Worker;
using Main.Scripts.Gameplay.Features.Building;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;
using Main.Scripts.Gameplay.Features.WorkerAcceptor;
using UniRx;

namespace Main.Scripts.Gameplay.Features.Worker.Commands
{
    public class ExtractWorkerCommand : IWorkerCommand
    {
        private WorkerGO _workerGo;
        private readonly IExtractable _extractable;
        private readonly IWorkerAcceptor _acceptor;

        public ExtractWorkerCommand(IExtractable extractable, IWorkerAcceptor destination)
        {
            _extractable = extractable;
            _acceptor = destination;
        }

        public IObservable<Unit> Execute(WorkerGO workerGo)
        {
            _workerGo = workerGo;
            return _workerGo.StartExtractProcess(_extractable, _acceptor);
        }
    }
}