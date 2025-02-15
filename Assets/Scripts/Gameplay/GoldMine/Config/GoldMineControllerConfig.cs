using UnityEngine;

namespace Gameplay.GoldMine.Config
{
    [CreateAssetMenu(fileName = "GoldMine Controller Config", menuName = "Gold Mine/GoldMine Controller Config")]
    public class GoldMineControllerConfig : ScriptableObject
    {
        public int StartSpawn;
        public Vector3 CenterPosition;
        public float MinRadiusSpawn;
        public float MaxRadiusSpawn;
    }
}
