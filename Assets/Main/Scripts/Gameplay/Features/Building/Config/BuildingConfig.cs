using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.BuildingStrategy;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building {
    [CreateAssetMenu(fileName = "Building Config", menuName = "Building/Building config", order = 0)]
    public class BuildingConfig : ScriptableObject {
        public bool EnableBuild;
        public bool CreateOnStartup;
        public string Name;
        public Sprite Sprite;
        public BuildingType Type;
        public List<BuildResourceCondition> BuildResourceConditions;
        public BaseBuildStrategySO strategySo;
        public StartupBuildingConfig StartupBuildingConfig;
    }
}

