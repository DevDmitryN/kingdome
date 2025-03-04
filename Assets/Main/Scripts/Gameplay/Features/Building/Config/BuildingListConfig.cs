using System.Collections.Generic;

using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building
{
    [CreateAssetMenu(fileName = "BuildingListConfig", menuName = "Building/Building list config", order = 0)]
    public class BuildingListConfig : ScriptableObject
    {
        
        public List<BuildingConfig> BuildngConfigs;
    }
}
