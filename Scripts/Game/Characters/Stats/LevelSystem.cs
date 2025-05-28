using Unity.Burst;
using Unity.Entities;

[BurstCompile]
[UpdateAfter(typeof(ExperienceSystem))]
public partial struct LevelSystem : ISystem
{
    private const float BaseXP = 100f;
    private const float GrowthFactor = 1.25f;

    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<LevelComponent>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (level, xp) in SystemAPI.Query<RefRW<LevelComponent>, RefRO<ExperienceComponent>>())
        {
            float totalXP = xp.ValueRO.GeneralXP;
            level.ValueRW.CurrentXP = totalXP;

            while (level.ValueRW.CurrentXP >= level.ValueRW.RequiredXP)
            {
                level.ValueRW.CurrentXP -= level.ValueRW.RequiredXP;
                level.ValueRW.Level += 1;
                level.ValueRW.RequiredXP = BaseXP * level.ValueRW.Level * GrowthFactor;
            }
        }
    }
}
