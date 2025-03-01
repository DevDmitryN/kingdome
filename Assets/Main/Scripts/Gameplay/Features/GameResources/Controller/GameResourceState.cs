using System.Collections.Generic;
using Main.Scripts.Gameplay.Features.GameResources.Enums;
using UnityEngine;

namespace Main.Scripts.Gameplay.Features.GameResources.Controller
{
    public class GameResourceState
    {
        public interface IGameResourceStateValue
        {
            public float CurrentValue { get; }
            public float PrevValue { get; }
        }
        private class GameResourceStateValue : IGameResourceStateValue
        {
            public float CurrentValue { get; set; }
            /// <summary>
            /// Предыдущее значение
            /// </summary>
            public float PrevValue { get; set; }
        }

        private Dictionary<GameResourceType, GameResourceStateValue> _states = new();

        public void AddType(GameResourceType type, float initValue)
        {
            _states.Add(type, new GameResourceStateValue() { CurrentValue = initValue});
        }

        public bool AddAmount(GameResourceType type, float amount, out IGameResourceStateValue stateValue)
        {
            stateValue = null;
            if (_states.TryGetValue(type, out var state))
            {
                state.PrevValue = state.CurrentValue;
                state.CurrentValue += amount;
                stateValue = state;
                return true;
            }
            else
            {
                Debug.LogWarning("Состояние ресурса не найдено");
            }

            return false;
        }
    }
}