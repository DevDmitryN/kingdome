using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.Building.Factory;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingUIList : MonoBehaviour
    {
        [Inject] private BuildingListConfig _config;
        [Inject] private IBuildingListItemFactory _uiItemsFactory;
        [Inject] private BuildingController _controller;

        private List<BuildingUIListItem> _uiItems = new();

        public void Init()
        {
            CreateListItems();
        }

        private void CreateListItems()
        {
            foreach (var config in _config.BuildngConfigs)
            {
                var listItem = CreateItem(config);
                _uiItems.Add(listItem);
            }
        }

        private BuildingUIListItem CreateItem(BuildingConfig config)
        {
            var listItem = _uiItemsFactory.Create(transform, config);

            listItem.OnSelect
                .TakeUntilDestroy(this)
                .Subscribe(value => {
                    _controller.StartBuilding(config);
                });

            return listItem;
        }

    }

}
