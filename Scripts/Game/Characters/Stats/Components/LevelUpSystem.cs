using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct LevelUpSystem : ISystem
{
    private const int BaseXP = 100;
    private const float GrowthFactor = 1.5f;
    private const int PerkPointsPerLevel = 1;

    public void OnUpdate(ref SystemState state)
    {
        foreach (var (level, entity) in SystemAPI.Query<RefRW<LevelComponent>>().WithEntityAccess())
        {
            while (level.ValueRO.Experience >= level.ValueRO.ExperienceToNextLevel)
            {
                level.ValueRW.Experience -= level.ValueRO.ExperienceToNextLevel;
                level.ValueRW.Level += 1;
                level.ValueRW.ExperienceToNextLevel = (int)(BaseXP * level.ValueRW.Level * GrowthFactor);
                level.ValueRW.AvailablePerkPoints += PerkPointsPerLevel;

                UnityEngine.Debug.Log($"Entity {entity.Index} leveled up to {level.ValueRW.Level}!");
            }
        }
    }
}
