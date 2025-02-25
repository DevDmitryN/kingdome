using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Worker.Config
{
    [CreateAssetMenu(fileName = "Worker Config", menuName = "Worker/Worker Config", order = 0)]
    public class WorkerConfigSO : ScriptableObject
    {
        public float TakeAmount;
        public float ExtractSpeed;
        public float Speed;
    }
}