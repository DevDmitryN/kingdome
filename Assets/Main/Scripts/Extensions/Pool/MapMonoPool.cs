using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions.Pool
{
    public class MapMonoPool<T> : IMapPool<T, MonoPool<T>> where T : MonoBehaviour
    {
        private Dictionary<string, MonoPool<T>> _poolMap = new ();

        public void Add(T prefab, MonoPool<T> pool)
        {
            _poolMap.Add(prefab.GetType().FullName, pool);
        }
        
        public MonoPool<T> Get(T prefab)
        {
            if (_poolMap.TryGetValue(prefab.GetType().FullName, out var value))
            {
                return value;
            }

            throw new Exception("Пул не найден");
        }

        public Dictionary<string, MonoPool<T>>.ValueCollection Values()
        {
            return _poolMap.Values;
        }
    }
    
}