using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct LowerRealmMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float dt = SystemAPI.Time.DeltaTime;

        foreach (var (unit, transform) in
            SystemAPI.Query<RefRO<UnitComponent>, RefRW<LocalTransform>>()
                     .WithAll<TagLowerRealm>())
        {
            transform.ValueRW.Position += unit.ValueRO.Direction * unit.ValueRO.Speed * dt;
        }
    }
}
