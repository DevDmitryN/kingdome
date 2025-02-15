using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions.Pool
{
    public abstract class BasePool<T> : IObjectPool<T> where T : MonoBehaviour
    {
        protected List<T> _pool = new ();

        public List<T> All => _pool.ToList();

        public List<T> AllActive => _pool.Where(_ => _.gameObject.activeSelf).ToList();
        
        public int CountActive => _pool.Count(_ => _.gameObject.activeSelf);
        
        public bool IsExistActive => _pool.Any(_ => _.gameObject.activeSelf);

        protected abstract T CreateObject();
        
        public T Get()
        {
            foreach (var obj in _pool)
            {
                if (!obj.gameObject.activeSelf)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }
            
            var instance = CreateObject();
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Hide(T obj)
        {
            obj.gameObject.SetActive(false);
        }
        
        
        public void HideAll()
        {
            foreach (var obj in _pool)
            {
                obj.gameObject.SetActive(false);
            }
        }
        
        public void Hide(T obj, int delay)
        {
        }
    }
}