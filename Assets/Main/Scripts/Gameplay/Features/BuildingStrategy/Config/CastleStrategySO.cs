using System;
using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    [CreateAssetMenu(fileName = "Castle Building Strategy", menuName = "Building/Strategy/Castle", order = 0)]
    public class CastleStrategySO : BaseBuildStrategySO
    {
        public override StrategyType ConfigStrategyType => StrategyType.Castle;
    }
}