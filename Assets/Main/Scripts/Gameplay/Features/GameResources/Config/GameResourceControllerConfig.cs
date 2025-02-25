using System.Collections.Generic;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.GameResources.Config
{
    // TODO переименовать в GameResourcesConfig
    [CreateAssetMenu(fileName = "Game resources controller config", menuName = "Game resources/config", order = 0)]
    public class GameResourceControllerConfig : ScriptableObject
    {
        public List<GameResourceConfig> GameResources;
    }
}