using UnityEngine;

namespace Main.Scripts.Gameplay.Core.Moving
{
    public class FixNotPhysicMoving : IMoving
    {
        private readonly float _speed;
        private readonly float _endDistance;

        public bool IsEnded { get; private set; }

        public FixNotPhysicMoving(float speed, float endDistance)
        {
            _speed = speed;
            _endDistance = endDistance;
        }

        public Vector3 Move(Vector3 startPosition, Vector3 endPosition)
        {
            // Вычисляем направление движения
            var direction = (endPosition - startPosition).normalized;

            // Перемещаем героя в направлении цели
            var newPosition = startPosition + direction * _speed * Time.fixedDeltaTime;

            // Проверяем, достиг ли герой цели
            if (Vector2.Distance(newPosition, endPosition) < _endDistance)
            {
                IsEnded = true;
            }

            return newPosition;
        }
    }
}