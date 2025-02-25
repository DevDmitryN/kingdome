using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Main.Scripts.Gameplay.Features.ResourceContainer.Config
{
    [CreateAssetMenu(fileName = "Extractable config", menuName = "Gold Mine/Extractable config", order = 0)]
    public class ExtractableSO : ScriptableObject
    {
        [FormerlySerializedAs("ResourceType")] public GameResourceType gameResourceType;
        public float TotalAmount;
        public Sprite Image;
    }
}