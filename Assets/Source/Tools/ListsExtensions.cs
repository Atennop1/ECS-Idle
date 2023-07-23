using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Learning.Tools
{
    public static class ListsExtensions
    {
        public static List<int> Unpack(this List<EcsPackedEntity> packed, EcsWorld world)
        {
            var result = new List<int>();

            foreach (var packedEntity in packed)
            {
                packedEntity.Unpack(world, out var entity);
                result.Add(entity);
            }

            return result;
        }

        public static Dictionary<T, Y> ToDictionary<T, Y>(this List<T> keys, List<Y> values)
        {
            var result = new Dictionary<T, Y>();
            
            for (var i = 0; i < keys.Count; i++) 
                result.Add(keys[i], values[i]);

            return result;
        }
    }
}