using System;
using Gameplay.GoldMine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Worker.Config
{
    [Serializable]
    public class WorkerSpawnConfig
    {
        [FormerlySerializedAs("ResourceType")] public GameResourceType gameResourceType;
        public int InitAmount;
    }
}