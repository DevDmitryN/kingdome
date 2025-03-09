using System;
using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.BuildingStrategy
{
    [CreateAssetMenu(fileName = "Attack In Radius Building Strategy", menuName = "Building/Strategy/Attack In Radius", order = 0)]
    public class AttackInRadiusBuildStrategySO : BaseBuildStrategySO
    {
        public override StrategyType ConfigStrategyType => StrategyType.AttackInRadius;
    }
}