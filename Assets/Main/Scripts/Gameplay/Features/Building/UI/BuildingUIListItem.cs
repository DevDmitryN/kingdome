using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.Gameplay.Features.Building 
{
    public class BuildingUIListItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;

        private Button _button;

        //private Subject<BuildingConfig> _onSelect = new ();
        public IObservable<Unit> OnSelect => _button.OnClickAsObservable();

        private void Awake()
        {
            _button = GetComponent<Button>();
            // _button.OnClickAsObservable()
            //     .TakeUntilDestroy(this)
            //     .Subscribe(value => _onSelect.OnNext());
        }

        // public void SetConfig(BuildingConfig config) 
        // {
        //     _image.sprite = config.Sprite;
        //     _name.text = config.Name;
        // }

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

        private void OnClick() 
        {

        }
    }

}
