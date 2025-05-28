using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

namespace InfiniteRealms.Stats
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct ExperienceGainSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (exp, entity) in SystemAPI.Query<RefRW<ExperienceComponent>>().WithEntityAccess())
            {
                // Пример: проверка событий и добавление опыта
                if (PlayerDidDialogue(entity))
                {
                    exp.ValueRW.CharismaXP += 10;
                    TryLevelUp(ref exp.ValueRW.CharismaLevel, ref exp.ValueRW.CharismaXP);
                }

                if (PlayerShotHit(entity))
                {
                    exp.ValueRW.ShootingXP += 5;
                    TryLevelUp(ref exp.ValueRW.ShootingLevel, ref exp.ValueRW.ShootingXP);
                }

                // и т.д.
            }
        }

        private bool PlayerDidDialogue(Entity entity) => false; // TODO: подключить ивенты
        private bool PlayerShotHit(Entity entity) => false;

        private void TryLevelUp(ref int level, ref int xp)
        {
            int xpToLevel = ExperienceUtils.GetRequiredXP(level);
            if (xp >= xpToLevel)
            {
                xp -= xpToLevel;
                level++;
                Debug.Log($"Level Up! New level: {level}");
            }
        }
    }
}
