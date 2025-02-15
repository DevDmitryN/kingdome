using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Extensions.Pool
{
    public class DiMonoPool<T> : BasePool<T> where T : MonoBehaviour
    {
        private readonly DiContainer _container;
        private readonly T _prefab;
        private readonly Transform _parent;

        public DiMonoPool(DiContainer container, T prefab, Transform rect, int count) 
        {
            _container = container;
            _pool = new List<T>();
            _prefab = prefab;
            _parent = rect;
            for (int i = 0; i < count; i++)
                CreateObject();
        }

        protected override T CreateObject()
        {
            try
            {
                var obj = _container.InstantiatePrefabForComponent<T>(_prefab, _parent);
                obj.gameObject.SetActive(false);
                _pool.Add(obj);
                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e; 
            }
        }
    }
}