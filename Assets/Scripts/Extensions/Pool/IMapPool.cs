using System.Collections.Generic;

namespace Extensions.Pool
{
    public interface IMapPool<TYPE, POOL_TYPE> where POOL_TYPE : IObjectPool<TYPE>
    {
        public void Add(TYPE poolTypeValues, POOL_TYPE pool);
        public POOL_TYPE Get(TYPE poolTypeValues);
        public Dictionary<string, POOL_TYPE>.ValueCollection Values();
    }
}