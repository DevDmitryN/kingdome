using System;
using JetBrains.Annotations;
using Main.Scripts.Gameplay.Core.Service.Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildProcessResult
    {
        public bool IsBuild;
        public Vector3 Position;
        public BuildingPreviewMono Preview;
    }
    
    public class BuildProcessMono : MonoBehaviour
    {
        [Inject] private IInputService _inputService;
        
        [CanBeNull] private BuildingPreviewMono _item = null;
        private readonly Subject<BuildProcessResult> _buildFinishedEvent = new ();
        
        public IObservable<BuildProcessResult> StartProcess(BuildingPreviewMono item)
        {
            _item = item;
            return _buildFinishedEvent.AsObservable();
        }

        private void Update()
        {
            if (_item == null) 
                return;

            _item.transform.position = _inputService.CursorPosition;

            if (_inputService.IsClicked)
            {
                _buildFinishedEvent.OnNext(
                new (){
                    IsBuild = true,
                    Position = _item.transform.position,
                    Preview = _item
                });
                _item = null;
            }
        }
    }
}