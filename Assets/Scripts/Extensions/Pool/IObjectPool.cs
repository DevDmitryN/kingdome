using System.Collections.Generic;

namespace Extensions.Pool
{
    public interface IObjectPool<T>
    {
        public List<T> All { get; }
        public List<T> AllActive { get; }
        public int CountActive { get; }
        public bool IsExistActive { get; }
        public T Get();
        public void Hide(T obj);
        public void HideAll();
        public void Hide(T obj, int delay);
    }
}