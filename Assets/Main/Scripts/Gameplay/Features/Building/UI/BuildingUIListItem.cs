using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building 
{
    public class BuildingUIListItem : MonoBehaviour
    {
        [Inject] private CommonBuildConfig _commonConfig;
        [Inject] private BuildingConfig _config;
        
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;

        private Button _button;
        public IObservable<Unit> OnSelect => _button.OnClickAsObservable();

        private void Awake()
        {
            _button = GetComponent<Button>();
            Setup();
        }

        private void Setup()
        {
            _image.sprite = _config.Sprite;
            _name.text = _config.Name;
            _image.color = _commonConfig.DisabledColor;
        }
    }

}
