using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building  
{
    public class BuildingUIList : MonoBehaviour
    {
       [Inject] private BuildingListConfig _config;
       [Inject] private BuildingUIListItem _itemPrefab;

       private List<BuildingUIListItem> _uiItems = new ();

       public void Init() 
       {
            CreateListItems();
       }

       private void CreateListItems()
        {
            foreach (var config in _config.BuildngConfigs)
            {
                var listItem = Instantiate(_itemPrefab, transform)
                    .SetImage(config.Sprite)
                    .SetName(config.Name);

                _uiItems.Add(listItem);
            }
        }
    }

}
