using System.Collections.Generic;
using Extensions.Pool;
using Gameplay.GoldMine;
using UnityEngine;
using Zenject;

namespace Extensions.Spawner.Mono
{
    // TODO переписать спавнера так, чтобы они только спавнили. Вынести логику с монопулом отдельный класс
    // наверное можно даже поменять местами пул и спавнел, то есть в моно пуле будет использоваться спавнер
    public class DiMonoSpawner<T, TConfigType> : ISpawner<T> where T : MonoBehaviour
    {
        private readonly T _gameObject;
        private readonly TConfigType _config;
        private readonly Transform _folder;
        private readonly IObjectPool<T> _pool;

        public DiMonoSpawner(DiContainer diContainer, T gameObject, Transform folder, TConfigType config)
        {
            _gameObject = gameObject;
            _folder = folder;
            _config = config;
            _pool = new DiMonoPool<T, TConfigType>(diContainer, gameObject, folder, 10, config);
        }
        
        public T Spawn(Vector3 position)
        {
            var item = _pool.Get();
            item.transform.position = position;
            item.gameObject.SetActive(true);
            return item;
        }

        public T Spawn(Vector3 position, List<object> args)
        {
            return Spawn(position);
        }

        public void Hide(T mine)
        {
            _pool.Hide(mine);
        }   
    }
}