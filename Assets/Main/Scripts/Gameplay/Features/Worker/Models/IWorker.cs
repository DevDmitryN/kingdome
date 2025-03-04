using System;
using Main.Scripts.Gameplay.Features.ResourceContainer.Models;

namespace Main.Scripts.Gameplay.Features.Worker.Models
{
    public interface IWorker
    {
        IObservable<float> Extract(IExtractable extractable);
        WorkExtractedInfo ExtractedInfo { get; }
        WorkExtractedInfo returnExtractedData();
    }
}