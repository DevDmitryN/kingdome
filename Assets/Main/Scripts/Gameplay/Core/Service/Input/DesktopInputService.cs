using UnityEngine;
using Zenject;
using CameraType = Main.Scripts.Gameplay.Installers.Tokens.CameraType;

namespace Main.Scripts.Gameplay.Core.Service.Input
{
    public class DesktopInputService : IInputService
    {
        [Inject(Id = CameraType.Main)] private Camera _camera;
        
        public Vector3 CursorPosition
        {
            get
            {
                var mousePosition = UnityEngine.Input.mousePosition;
                return _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.nearClipPlane));
            }
        }

        public bool IsClicked => UnityEngine.Input.GetMouseButtonDown(0);
    }
}