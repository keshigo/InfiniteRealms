using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace InfiniteRealms.Systems.Movement
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct RealmMovementSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerControlledTag>();
        }

        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            // ”правление с клавиатуры
            float2 input = float2.zero;
            if (Input.GetKey(KeyCode.W)) input.y += 1;
            if (Input.GetKey(KeyCode.S)) input.y -= 1;
            if (Input.GetKey(KeyCode.A)) input.x -= 1;
            if (Input.GetKey(KeyCode.D)) input.x += 1;

            if (math.lengthsq(input) < 0.001f)
                return;

            float2 normalizedInput = math.normalize(input);

            // ¬ерхний мир Ч быстрое движение
            foreach ((RefRW<LocalTransform> transform, Entity entity) in SystemAPI.Query<RefRW<LocalTransform>>()
                     .WithAll<PlayerControlledTag, TagUpperRealm>()
                     .WithEntityAccess())
            {
                float speed = 5f;
                transform.ValueRW.Position.xy += normalizedInput * speed * deltaTime;
            }

            // Ќижний мир Ч медленное движение
            foreach ((RefRW<LocalTransform> transform, Entity entity) in SystemAPI.Query<RefRW<LocalTransform>>()
                     .WithAll<PlayerControlledTag, TagLowerRealm>()
                     .WithEntityAccess())
            {
                float speed = 2.5f;
                transform.ValueRW.Position.xy += normalizedInput * speed * deltaTime;
            }
        }
    }
}
