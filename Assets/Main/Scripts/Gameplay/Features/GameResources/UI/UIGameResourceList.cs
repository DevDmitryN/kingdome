using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.GameResources.UI
{
    public class UIGameResourceList : MonoBehaviour
    {
        [Inject] private UIGameResourceListItem _listItemPrefab;
        
        [Inject] private GameResourceController _gameResourceController;
        [Inject] private GameResourceControllerConfig _gameResourceControllerConfig;
        

        private List<UIGameResourceListItem> _uiGameResources = new();

        public void Init()
        {
            CreateListItems();
        }

        private void CreateListItems()
        {
            foreach (var gameResourceConfig in _gameResourceControllerConfig.GameResources)
            {
                var listItem = Instantiate(_listItemPrefab, transform)
                    .SetConfig(gameResourceConfig);
                _uiGameResources.Add(listItem);
            }

           
        }
    }
}