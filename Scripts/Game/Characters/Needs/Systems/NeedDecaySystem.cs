using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public partial struct NeedDecaySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (need, config) in SystemAPI.Query<RefRW<Need>, RefRO<NeedDecayConfig>>())
        {
            ref var n = ref need.ValueRW;

            // Уменьшаем таймеры
            n.HungerTimer += deltaTime;
            n.HygieneTimer += deltaTime;
            n.FunTimer += deltaTime;
            n.SocialTimer += deltaTime;
            n.BladderTimer += deltaTime;
            n.EnergyTimer += deltaTime;

            // По каждому виду потребности
            if (n.HungerTimer >= config.ValueRO.HungerDecayInterval)
            {
                n.Hunger = math.max(0f, n.Hunger - config.ValueRO.DecayAmount);
                n.HungerTimer = 0;
            }

            if (n.HygieneTimer >= config.ValueRO.HygieneDecayInterval)
            {
                n.Hygiene = math.max(0f, n.Hygiene - config.ValueRO.DecayAmount);
                n.HygieneTimer = 0;
            }

            if (n.FunTimer >= config.ValueRO.FunDecayInterval)
            {
                n.Fun = math.max(0f, n.Fun - config.ValueRO.DecayAmount);
                n.FunTimer = 0;
            }

            if (n.SocialTimer >= config.ValueRO.SocialDecayInterval)
            {
                n.Social = math.max(0f, n.Social - config.ValueRO.DecayAmount);
                n.SocialTimer = 0;
            }

            if (n.BladderTimer >= config.ValueRO.BladderDecayInterval)
            {
                n.Bladder = math.max(0f, n.Bladder - config.ValueRO.DecayAmount);
                n.BladderTimer = 0;
            }

            if (n.EnergyTimer >= config.ValueRO.EnergyDecayInterval)
            {
                n.Energy = math.max(0f, n.Energy - config.ValueRO.DecayAmount);
                n.EnergyTimer = 0;
            }
        }
    }
}
