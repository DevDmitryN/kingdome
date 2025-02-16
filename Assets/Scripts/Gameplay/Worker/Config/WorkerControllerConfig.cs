using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Worker.Config
{
    [CreateAssetMenu(fileName = "Worker Controller Config", menuName = "Worker/Controller Config", order = 0)]
    public class WorkerControllerConfig : ScriptableObject
    {
        public List<WorkerSpawnConfig> WorkerSpawnConfigs;
        public Vector3 CenterPosition;
        public float MinRadiusSpawn;
        public float MaxRadiusSpawn;
    }
}