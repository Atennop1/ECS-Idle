using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace Learning.Miners
{
    public sealed class PackedMinerEntitiesFactory : MonoBehaviour
    {
        public List<EcsPackedEntity> Create(IEcsSystems systems, int length)
        {
            var world = systems.GetWorld();
            var result = new List<EcsPackedEntity>();

            for (var i = 0; i < length; i++)
            {
                var entity = world.NewEntity();
                var packedEntity = world.PackEntity(entity);
                result.Add(packedEntity);
            }

            return result;
        }
    }
}