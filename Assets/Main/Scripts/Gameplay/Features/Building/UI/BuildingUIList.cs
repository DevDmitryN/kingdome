using System.Collections.Generic;
using System.Linq;
using Main.Scripts.Gameplay.Features.Building.Factory;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
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
        [Inject] private GameResourceController _resourceController;

        private List<BuildingUIListItem> _uiItems = new();

        public void Init()
        {
            CreateListItems();
            _resourceController.ResourceAmountChangedEvent
                .TakeUntilDestroy(this)
                .Subscribe(response =>
                {
                    foreach (var item in _uiItems)
                    {
                        item.UpdateEnabledState(response.Type, response.NewValue);
                    }
                });
        }

        private void CreateListItems()
        {
            var configs = _config.BuildngConfigs.Where(v => v.EnableBuild);

            foreach (var config in configs)
            {
                var listItem = CreateItem(config);
                
                foreach (var resourceStateValue in _resourceController.CurrentState)
                {
                    listItem.UpdateEnabledState(resourceStateValue.Type, resourceStateValue.CurrentValue);
                }
                
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
