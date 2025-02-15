using UnityEngine;

namespace Gameplay.GoldMine.Config
{
    [CreateAssetMenu(fileName = "Extractable config", menuName = "Gold Mine/Extractable config", order = 0)]
    public class ExtractableSO : ScriptableObject
    {
        public float TotalAmount;
    }
}