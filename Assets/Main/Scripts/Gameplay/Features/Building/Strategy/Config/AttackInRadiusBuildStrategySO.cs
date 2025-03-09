using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    [CreateAssetMenu(fileName = "Attack In Radius Building Strategy", menuName = "Building/Strategy/Attack In Radius", order = 0)]
    public class AttackInRadiusBuildStrategySO : BaseBuildStrategySO
    {
        public override Type ConfigStrategyType => typeof(AttackDistanceStrategy);
    }
}