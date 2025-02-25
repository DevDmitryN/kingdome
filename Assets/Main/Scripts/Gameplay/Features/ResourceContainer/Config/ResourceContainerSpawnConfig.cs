using System;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UnityEngine.Serialization;

namespace Main.Scripts.Gameplay.Features.ResourceContainer.Config
{
    [Serializable]
    public class ResourceContainerSpawnConfig
    {
        [FormerlySerializedAs("ResourceType")] public GameResourceType gameResourceType;
        public int InitAmount;
    }
}