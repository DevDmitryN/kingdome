using Main.Scripts.Gameplay.Features.Building;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building {
    [CreateAssetMenu(fileName = "Building Config", menuName = "Building/Building config", order = 0)]
    public class BuildingConfig : ScriptableObject {
        public string Name;
        public Sprite Sprite;
        public BuildingType Type;
    }
}

