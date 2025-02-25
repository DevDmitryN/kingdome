using System;
using UnityEngine.Serialization;

namespace Gameplay.GoldMine.Config
{
    [Serializable]
    public class ResourceContainerSpawnConfig
    {
        [FormerlySerializedAs("ResourceType")] public GameResourceType gameResourceType;
        public int InitAmount;
    }
}