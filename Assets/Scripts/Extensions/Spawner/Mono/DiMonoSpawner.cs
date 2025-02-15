using Extensions.Pool;
using Gameplay.GoldMine;
using UnityEngine;
using Zenject;

namespace Extensions.Spawner.Mono
{
    public class DiMonoSpawner<T> : ISpawner<T> where T : MonoBehaviour
    {
        private readonly T _gameObject;
        private readonly Transform _folder;
        private readonly IObjectPool<T> _pool;

        public DiMonoSpawner(DiContainer diContainer, T gameObject, Transform folder)
        {
            _gameObject = gameObject;
            _folder = folder;
            _pool = new DiMonoPool<T>(diContainer, gameObject, folder, 10);
        }
        
        public T Spawn(Vector3 position)
        {
            var item = _pool.Get();
            item.transform.position = position;
            item.gameObject.SetActive(true);
            return item;
        }

        public void Hide(T mine)
        {
            _pool.Hide(mine);
        }
    }
}