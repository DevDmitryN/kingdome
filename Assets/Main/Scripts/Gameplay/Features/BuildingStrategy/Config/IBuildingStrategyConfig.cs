using System;
using Main.Scripts.Gameplay.Features.Building;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    public interface IBuildingStrategyConfig 
    {
        StrategyType ConfigStrategyType { get; }
    }
}