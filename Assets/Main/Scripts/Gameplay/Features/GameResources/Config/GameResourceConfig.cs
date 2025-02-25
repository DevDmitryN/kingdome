using System;
using Gameplay.GoldMine;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UnityEngine;
using UnityEngine.UIElements;

namespace Main.Scripts.Gameplay.Features.GameResources.Config
{
    [Serializable]
    public class GameResourceConfig
    {
        public GameResourceType ResourceType;
        public Sprite Image;
        public float InitAmount;
    }
}