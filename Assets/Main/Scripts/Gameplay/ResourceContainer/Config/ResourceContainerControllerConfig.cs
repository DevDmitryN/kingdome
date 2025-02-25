using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.GoldMine.Config
{
    [CreateAssetMenu(fileName = "Resource Controller Config", menuName = "Resources/Resource Controller Config")]
    public class ResourceContainerControllerConfig : ScriptableObject
    {
        public List<ResourceContainerSpawnConfig> SpawnConfigs;
        public Vector3 CenterPosition;
        public float MinRadiusSpawn;
        public float MaxRadiusSpawn;

        public ResourceContainerSpawnConfig GetSpawnConfig(ResourceType resourceType)
        {
            return SpawnConfigs.Find(v => v.ResourceType == resourceType);
        }
    }
}
