using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions.Pool
{
    public class MonoPool<T> : BasePool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        
        public MonoPool(T prefab, Transform rect, int count)
        {
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
                var obj = GameObject.Instantiate(_prefab, _parent);
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