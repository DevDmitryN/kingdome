using System;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UnityEngine.Serialization;

namespace Main.Scripts.Gameplay.Features.Worker.Config
{
    [Serializable]
    public class WorkerSpawnConfig
    {
        [FormerlySerializedAs("ResourceType")] public GameResourceType gameResourceType;
        public int InitAmount;
    }
}