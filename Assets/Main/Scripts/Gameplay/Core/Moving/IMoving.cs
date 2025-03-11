using UnityEngine;

namespace Main.Scripts.Gameplay.Core.Moving
{
    public interface IMoving
    {
        bool IsEnded { get; }
        Vector3 Move(Vector3 startPosition, Vector3 endPosition);
    }
}