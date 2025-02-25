using System;
using Gameplay.GoldMine;
using UnityEngine;

namespace Gameplay.Worker.Config
{
    [Serializable]
    public class WorkerSpawnConfig
    {
        public ResourceType ResourceType;
        public int InitAmount;
    }
}