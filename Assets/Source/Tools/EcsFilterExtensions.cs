using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Learning.Tools
{
    public static class EcsFilterExtensions
    {
        public static List<T> GetEntities<T>(this EcsFilter filter, EcsPool<T> pool) where T: struct
        {
            var result = new List<T>(filter.GetEntitiesCount());

            foreach (var entity in filter) 
                result.Add(pool.Get(entity));

            return result;
        }
    }
}