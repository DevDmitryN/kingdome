using System;

namespace Gameplay.GoldMine.Config
{
    [Serializable]
    public class ResourceContainerSpawnConfig
    {
        public ResourceType ResourceType;
        public int InitAmount;
    }
}