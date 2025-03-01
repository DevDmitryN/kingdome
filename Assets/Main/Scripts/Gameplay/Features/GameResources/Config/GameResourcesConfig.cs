using System.Collections.Generic;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.GameResources.Config
{
    // TODO переименовать в GameResourcesConfig
    [CreateAssetMenu(fileName = "Game resources config", menuName = "Game resources/config", order = 0)]
    public class GameResourcesConfig : ScriptableObject
    {
        public List<GameResourceConfig> GameResources;
    }
}