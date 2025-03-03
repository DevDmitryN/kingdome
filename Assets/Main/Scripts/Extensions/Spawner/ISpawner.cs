using System.Collections.Generic;
using Gameplay.GoldMine;
using UnityEngine;

namespace Extensions.Spawner
{
    public interface ISpawner<T> where T : MonoBehaviour
    {
        T Spawn(Vector3 position);
        T Spawn(Vector3 position, List<object> args);
        // TODO убрать этот метод
        void Hide(T mine);
    }
}