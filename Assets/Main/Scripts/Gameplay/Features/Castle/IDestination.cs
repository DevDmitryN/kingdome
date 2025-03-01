using Main.Scripts.Gameplay.Features.Worker.Models;
using UnityEngine;

namespace Gameplay.Entities.Castle
{
    public interface IDestination
    {
        Transform Transform { get; }
        void AcceptWorker(IWorker worker);
    }
}