using System.Collections.Generic;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Worker.Config
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