using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building.Strategy
{
    [CreateAssetMenu(fileName = "Castle Building Strategy", menuName = "Building/Strategy/Castle", order = 0)]
    public class CastleStrategySO : BaseBuildStrategySO
    {
        public override Type ConfigStrategyType => typeof(CastleStrategy);
    }
}