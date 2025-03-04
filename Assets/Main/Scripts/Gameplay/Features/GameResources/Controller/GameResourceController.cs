using System;
using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Models;
using Main.Scripts.Gameplay.Features.GameResources.Models.Events;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.GameResources.Controller
{
    public class GameResourceController
    {
        [Inject]
        private readonly GameResourcesConfig _config;

        private GameResourceState _resourceState = new();
        private Subject<ResourceAmountChanged> _resourceAmountChanged = new();
        public IObservable<ResourceAmountChanged> ResourceAmountChangedEvent => _resourceAmountChanged
            .Where(v => v != null)
            .AsObservable();

        public List<GameResourceState.IGameResourceStateValue> CurrentState => _resourceState.GetState();

        public void Init()
        {
            foreach (var configGameResource in _config.GameResources)
            {
                _resourceState.AddType(configGameResource.ResourceType, configGameResource.InitAmount);
            }
        }

        public void AddResource(AddResourceParams paramsToChange)
        {
            if (_resourceState.AddAmount(paramsToChange.Type, paramsToChange.Value, out var stateValue))
            {
                _resourceAmountChanged.OnNext(new ()
                {
                    Type = paramsToChange.Type,
                    ChangeValue = paramsToChange.Value,
                    NewValue = stateValue.CurrentValue,
                    PrevValue = stateValue.PrevValue,
                });
            }
        }
    }
}