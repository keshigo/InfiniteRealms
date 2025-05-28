using Unity.Burst;
using Unity.Collections;
using Unity.Entities;


[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct ExperienceSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<GainedExperience>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (exp, entity) in SystemAPI.Query<GainedExperience>().WithEntityAccess())
        {
            if (!SystemAPI.HasComponent<ExperienceComponent>(entity)) continue;

            var experience = SystemAPI.GetComponent<ExperienceComponent>(entity);

            switch (exp.Type)
            {
                case ExperienceType.Strength:
                    experience.StrengthXP += exp.Amount;
                    break;
                case ExperienceType.Dexterity:
                    experience.DexterityXP += exp.Amount;
                    break;
                case ExperienceType.Endurance:
                    experience.EnduranceXP += exp.Amount;
                    break;
                case ExperienceType.Charisma:
                    experience.CharismaXP += exp.Amount;
                    break;
                case ExperienceType.Intimidation:
                    experience.IntimidationXP += exp.Amount;
                    break;
                case ExperienceType.Sniping:
                    experience.SnipingXP += exp.Amount;
                    break;
                case ExperienceType.Melee:
                    experience.MeleeXP += exp.Amount;
                    break;
                case ExperienceType.Engineering:
                    experience.EngineeringXP += exp.Amount;
                    break;
                case ExperienceType.General:
                    experience.GeneralXP += exp.Amount;
                    break;

            }


            SystemAPI.SetComponent(entity, experience);
            ecb.RemoveComponent<GainedExperience>(entity);
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
