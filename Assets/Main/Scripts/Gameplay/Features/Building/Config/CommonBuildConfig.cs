using UnityEngine;

namespace Main.Scripts.Gameplay.Features.Building
{
    [CreateAssetMenu(fileName = "Common build config", menuName = "Building/Common build config", order = 0)]
    public class CommonBuildConfig : ScriptableObject
    {
        public Color DisabledColor;
    }
}