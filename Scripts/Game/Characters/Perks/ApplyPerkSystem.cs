using Unity.Entities;
using Unity.Collections;
using Unity.Burst;

public struct ApplyPerkRequest : IComponentData
{
    public int PerkId;
}

[BurstCompile]
public partial struct ApplyPerkSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (level, perks, request, entity) in SystemAPI
                     .Query<RefRW<LevelComponent>, RefRW<PerkComponent>, RefRO<ApplyPerkRequest>>()
                     .WithEntityAccess())
        {
            if (level.ValueRO.AvailablePerkPoints > 0 && !perks.ValueRO.UnlockedPerks.Contains(request.ValueRO.PerkId))
            {
                perks.ValueRW.UnlockedPerks.Add(request.ValueRO.PerkId);
                level.ValueRW.AvailablePerkPoints -= 1;

                UnityEngine.Debug.Log($"Perk {request.ValueRO.PerkId} unlocked for entity {entity.Index}");
            }

            ecb.RemoveComponent<ApplyPerkRequest>(entity);
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
