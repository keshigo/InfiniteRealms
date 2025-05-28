using InfiniteRealms.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace InfiniteRealms.Systems
{
    /// <summary>
    /// Система переключения миров по запросу ToggleRealmRequest
    /// </summary>
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct RealmSwitchSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            // Ожидаем появления игрока
            state.RequireForUpdate<PlayerControlledTag>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            // Собираем все сущности, у которых есть и игрок, и запрос переключения
            var query = SystemAPI.QueryBuilder()
                                  .WithAll<PlayerControlledTag, ToggleRealmRequest>()
                                  .Build();
            using var entities = query.ToEntityArray(Allocator.Temp);

            foreach (var entity in entities)
            {
                // Переключаем Realm
                if (state.EntityManager.HasComponent<TagUpperRealm>(entity))
                {
                    ecb.RemoveComponent<TagUpperRealm>(entity);
                    ecb.AddComponent<TagLowerRealm>(entity);
                    Debug.Log("Switched → Lower Realm");
                }
                else
                {
                    ecb.RemoveComponent<TagLowerRealm>(entity);
                    ecb.AddComponent<TagUpperRealm>(entity);
                    Debug.Log("Switched → Upper Realm");
                }

                // Убираем запрос, чтобы не переключаться каждый кадр
                ecb.RemoveComponent<ToggleRealmRequest>(entity);
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }

        public void OnDestroy(ref SystemState state) { }
    }
}