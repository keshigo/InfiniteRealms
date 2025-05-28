using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[BurstCompile]
public partial struct RealmSwitchSystem : ISystem
{
    private bool _switchPressedLastFrame;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerControlledTag>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (!Input.GetKeyDown(KeyCode.R))
        {
            _switchPressedLastFrame = false;
            return;
        }

        if (_switchPressedLastFrame)
            return;

        _switchPressedLastFrame = true;

        var ecb = new EntityCommandBuffer(Allocator.Temp);

        var query = SystemAPI.QueryBuilder()
            .WithAll<PlayerControlledTag>()
            .WithOptions(EntityQueryOptions.IncludeDisabledEntities)
            .Build();

        var entities = query.ToEntityArray(Allocator.Temp);

        foreach (var entity in entities)
        {
            var hasUpper = state.EntityManager.HasComponent<TagUpperRealm>(entity);
            var hasLower = state.EntityManager.HasComponent<TagLowerRealm>(entity);

            if (hasUpper)
            {
                ecb.RemoveComponent<TagUpperRealm>(entity);
                ecb.AddComponent<TagLowerRealm>(entity);
                Debug.Log($"Switched {entity} to Lower Realm");
            }
            else if (hasLower)
            {
                ecb.RemoveComponent<TagLowerRealm>(entity);
                ecb.AddComponent<TagUpperRealm>(entity);
                Debug.Log($"Switched {entity} to Upper Realm");
            }
            else
            {
                ecb.AddComponent<TagUpperRealm>(entity);
                Debug.Log($"Initialized {entity} in Upper Realm");
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
        entities.Dispose();
    }
}
