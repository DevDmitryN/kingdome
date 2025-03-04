using System;
using Main.Scripts.Gameplay.Features.GameResources.Enums;

namespace Main.Scripts.Gameplay.Features.Building
{
    [Serializable]
    public class BuildResourceCondition
    {
        public GameResourceType ResourceType;
        public int RequiredValue;
    }
}