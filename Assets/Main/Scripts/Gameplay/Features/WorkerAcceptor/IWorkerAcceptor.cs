using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.WorkerAcceptor
{
    public interface IWorkerAcceptor
    {
        Vector3 Position { get; }
        void AcceptWorker(IWorker worker);
    }   
}