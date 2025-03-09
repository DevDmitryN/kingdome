using System;

namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    public interface IBuildingStrategyConfig 
    {
        Type ConfigStrategyType { get; }
    }
}