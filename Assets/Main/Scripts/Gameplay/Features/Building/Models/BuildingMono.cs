using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingMono : MonoBehaviour 
    {
        [Inject] private BuildingConfig _config;

        [SerializeField] private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite.sprite = _config.Sprite;
        }
    }
}