using System;
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

        public UIGameResourceListItem SetConfig(GameResourceConfig config)
        {
            if (config.Image != null)
            {
                _image.sprite = config.Image;
            }
           
            _amountText.text = config.InitAmount.ToString();
            return this;
        }

        public void SetValue(float value)
        {
            _amountText.text = value.ToString();
        }
    }
}