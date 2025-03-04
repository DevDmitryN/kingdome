using System;
using System.Collections.Generic;
using System.Linq;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
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
        [Inject] public BuildingConfig _config { get; private set; }
        
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;

        private List<ResourceConditionState> _conditionState = new ();
        
        public bool Enabled
        {
            get => _button.interactable;
            set => _button.interactable = value;
        }
        
        private Button _button;
        public IObservable<Unit> OnSelect => _button.OnClickAsObservable();

        
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.interactable = false;
            Setup();
        }

        private void Setup()
        {
            _image.sprite = _config.Sprite;
            _name.text = _config.Name;
            
            foreach (var condition in _config.BuildResourceConditions)
            {
                _conditionState.Add(new () { Condition = condition, IsValid = false });
            }
        }

        public void UpdateEnabledState(GameResourceType resourceType, float resourceValue)
        {
            var conditionState = _conditionState.FirstOrDefault(v => v.Condition.ResourceType == resourceType);
            if (conditionState != null)
            {
                conditionState.IsValid = resourceValue >= conditionState.Condition.RequiredValue;
            }

            Enabled = _conditionState.All(v => v.IsValid);
        }
        
        private class ResourceConditionState
        {
            public BuildResourceCondition Condition;
            public bool IsValid;
        }
    }

}
