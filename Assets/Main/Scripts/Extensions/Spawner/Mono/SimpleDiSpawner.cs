
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Extensions.Spawner.Mono
{
    public class SimpleDiSpawner<T> : ISpawner<T> where T : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private T _prefab;
        [Inject] private Transform _folder;

        public void Hide(T mine)
        {
            throw new System.NotImplementedException();
        }

        public T Spawn(Vector3 position)
        {
            var item = _container.InstantiatePrefabForComponent<T>(_prefab, _folder);
            item.transform.position = position;
            return item;
        }

        public T Spawn(Vector3 position, List<object> args)
        {
            var item = _container.InstantiatePrefabForComponent<T>(_prefab, _folder, args);
            item.transform.position = position;
            return item;
        }
    }
}