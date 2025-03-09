using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    [CreateAssetMenu(fileName = "Base Building Strategy", menuName = "Building/Strategy/Base", order = 0)]
    public abstract class BaseBuildStrategySO : ScriptableObject, IBuildingStrategyConfig
    {
        public virtual Type ConfigStrategyType => throw new System.NotImplementedException();
    }
}