// Scripts/Systems/Perk/ApplyPerkEffectsSystem.cs
using InfiniteRealms.Stats.Components;
using Unity.Entities;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class ApplyPerkEffectsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithAll<PlayerTag>()
            .ForEach((ref StatComponent stats, in DynamicBuffer<PerkComponent> perks, in DynamicBuffer<PerkEffect> effects) =>
            {
                foreach (var effect in effects)
                {
                    stats.Damage += effect.DamageBonus;
                    stats.Speed += effect.SpeedBonus;
                    stats.Health += effect.HealthBonus;
                }
            }).ScheduleParallel();
    }
}
