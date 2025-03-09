using System;
using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    [CreateAssetMenu(fileName = "Base Building Strategy", menuName = "Building/Strategy/Base", order = 0)]
    public abstract class BaseBuildStrategySO : ScriptableObject, IBuildingStrategyConfig
    {
        public virtual StrategyType ConfigStrategyType => StrategyType.None;
    }
}