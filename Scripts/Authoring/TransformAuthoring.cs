using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace InfiniteRealms.Authoring
{
    public class TransformAuthoring : MonoBehaviour
    {
        public float3 InitialPosition = float3.zero;
    }

    public class TransformAuthoringBaker : Baker<TransformAuthoring>
    {
        public override void Bake(TransformAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new LocalTransform
            {
                Position = authoring.InitialPosition,
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
    }
}
