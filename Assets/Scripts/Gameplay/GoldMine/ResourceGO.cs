using System;
using Gameplay.GoldMine.Config;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.GoldMine
{
    public class ResourceGO : MonoBehaviour, IExtractable
    {
        #region SerializeField

        [SerializeField] private GameObject _imageObject;

        #endregion

        #region PRIVATE

        private SpriteRenderer _imageSpriteRenderer;
        private readonly Subject<Unit> _onResourceEnded = new();
        private float _currentResourceAmount = 5;

        #endregion
        
        #region Поля IExtractable

        public ExtractableSO Info { get; private set; }
        public bool IsEnded { get; private set; }
        public Transform Transform => transform;
        public IObservable<Unit> OnEnded => _onResourceEnded.AsObservable();

        #endregion
       

        [Inject]
        private void Construct(ExtractableSO config)
        {
            Info = config;
           
        }

        private void OnEnable()
        {
            _imageSpriteRenderer = _imageObject.GetComponent<SpriteRenderer>();
            IsEnded = _currentResourceAmount == 0;
            Setup();
        }

        private void Setup()
        {
            _currentResourceAmount = Info.TotalAmount;
            _imageSpriteRenderer.sprite = Info.Image;
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