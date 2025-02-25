using Gameplay.GoldMine;
using Main.Scripts.Gameplay.Features.ResourceContainer.Config;
using Main.Scripts.Gameplay.Features.Worker.Models;

namespace Main.Scripts.Gameplay.Features.ResourceContainer.Models
{
    public interface IExtractable : IWorkable
    {
        ExtractableSO Info { get; }
        
        float Extract(float amount);
    }
}