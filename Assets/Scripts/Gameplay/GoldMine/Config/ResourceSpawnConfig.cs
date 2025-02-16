using System;

namespace Gameplay.GoldMine.Config
{
    [Serializable]
    public class ResourceSpawnConfig
    {
        public ResourceType ResourceType;
        public int InitAmount;
    }
}