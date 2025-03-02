using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.Gameplay.Features.Building 
{
    public class BuildingUIListItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        
        public BuildingUIListItem SetImage(Sprite image) 
        {
            _image.sprite = image;
            return this;
        }

        public BuildingUIListItem SetName(string name) 
        {
            _name.text = name;
            return this;
        }
    }

}
