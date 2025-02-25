using Main.Scripts.Gameplay.Features.GameResources.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.Gameplay.Features.GameResources.UI
{
    public class UIGameResourceListItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _amountText;
        
        private GameResourceConfig _config;

        public void SetConfig(GameResourceConfig config)
        {
            _config = config;

            if (config.Image != null)
            {
                _image.sprite = config.Image;
            }
           
            _amountText.text = config.InitAmount.ToString();
        }
    }
}