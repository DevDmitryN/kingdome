using Gameplay.GoldMine;
using UnityEngine;

namespace Extensions.Spawner
{
    public interface ISpawner<T> where T : MonoBehaviour
    {
        T Spawn(Vector3 position);
        void Hide(T mine);
    }
}