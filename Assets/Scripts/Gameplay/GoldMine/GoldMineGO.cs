using System;
using Gameplay.GoldMine.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.GoldMine
{
    public class GoldMineGO : MonoBehaviour, IExtractable
    {
        private readonly Subject<Unit> _onResourceEnded = new();
        private float _currentResourceAmount = 5;
        private ExtractableSO _config;
        
        public bool IsEnded { get; private set; }
        public Transform Transform => transform;
        public IObservable<Unit> OnEnded => _onResourceEnded.AsObservable();

        [Inject]
        private void Construct(ExtractableSO config)
        {
            _config = config;

            _currentResourceAmount = _config.TotalAmount;
        }

        private void OnEnable()
        {
            IsEnded = _currentResourceAmount == 0;
        }

        
        private float DoExtraction(float amount)
        {
            _currentResourceAmount -= amount;
            if (_currentResourceAmount == 0)
            {
                IsEnded = true;
                _onResourceEnded.OnNext(Unit.Default);
            }
            return amount;
        }
        
        // TODO переделать через визитера или команду
        public IObservable<float> Extract(float amount, float extractionSpeed)
        {
            return Observable
                .Timer(TimeSpan.FromSeconds(extractionSpeed))
                .Select(value => DoExtraction(amount));
        }
        
    }
}