

using UnityEngine;

namespace Main.Scripts.Gameplay.Core.Service.Input
{
    public interface IInputService
    {
        Vector3 CursorPosition { get; }
        bool IsClicked { get; }
    }
}