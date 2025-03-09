using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.WorkerAcceptor
{
    public class EmptyWorkerAcceptor : IWorkerAcceptor
    {
    
        public Vector3 Position => Vector3.zero;

        public void AcceptWorker(IWorker worker)
        {
           Debug.LogWarning("Пустой acceptor");
        }
    }
}