using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.Models;
using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;
using Zenject;

namespace Gameplay.Entities.Castle
{
    public class CastleGO : MonoBehaviour, IDestination
    {
        [Inject] private GameResourceController _resourceController;
        
        public Transform Transform => transform;

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