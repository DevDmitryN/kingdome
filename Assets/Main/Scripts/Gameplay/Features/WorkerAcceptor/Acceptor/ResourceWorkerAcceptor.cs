using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.WorkerAcceptor
{
    public class ResourceWorkerAcceptor : IWorkerAcceptor
    {
        [Inject] private Vector3 _position;
        [Inject] private GameResourceController _resourceController;

        public Vector3 Position => _position;

        public void AcceptWorker(IWorker worker)
        {
            var data = worker.returnExtractedData();
            _resourceController.AddResource(new ()
            {
                Type = data.ResourceType,
                Value = data.ExtractValue
            });
        }
    }
}