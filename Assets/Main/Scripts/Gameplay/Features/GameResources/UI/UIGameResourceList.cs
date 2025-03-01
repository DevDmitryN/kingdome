using System.Collections.Generic;
using System.Linq;
using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.GameResources.UI
{
    public class UIGameResourceList : MonoBehaviour
    {
        [Inject] private UIGameResourceListItem _listItemPrefab;
        
        [Inject] private GameResourceController _gameResourceController;
        [Inject] private GameResourcesConfig _gameResourcesConfig;
        

        private Dictionary<GameResourceType, UIGameResourceListItem> _uiGameResources = new();

        public void Init()
        {
            CreateListItems();

            _gameResourceController.ResourceAmountChangedEvent
                .TakeUntilDestroy(this)
                .Subscribe(v =>
                {
                    SetResourceValue(v.Type, v.NewValue);
                });
        }

        private void CreateListItems()
        {
            foreach (var gameResourceConfig in _gameResourcesConfig.GameResources)
            {
                var listItem = Instantiate(_listItemPrefab, transform)
                    .SetConfig(gameResourceConfig);
                _uiGameResources.Add(gameResourceConfig.ResourceType, listItem);
            }
        }

        private void SetResourceValue(GameResourceType type, float newValue)
        {
            if (_uiGameResources.TryGetValue(type, out var item))
            {
                item.SetValue(newValue);
            }
            else
            {
                Debug.LogWarning($"Ресурс на ui не найден {type}");
            }
        }
    }
}