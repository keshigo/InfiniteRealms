using Unity.Entities;
using UnityEngine;
using InfiniteRealms.Stats.Components;

namespace InfiniteRealms.Stats.Authoring
{
    public class StatsAuthoring : MonoBehaviour
    {
        public float Strength;
        public float Dexterity;
        public float Endurance;
        public float Charisma;
        public float Intimidation;

        public float Sniping;
        public float Melee;
        public float Engineering;

        public float Luck;
        public float Reputation;
    }

    public class StatsBaker : Baker<StatsAuthoring>
    {
        public override void Bake(StatsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new StatsComponent
            {
                Strength = authoring.Strength,
                Dexterity = authoring.Dexterity,
                Endurance = authoring.Endurance,
                Charisma = authoring.Charisma,
                Intimidation = authoring.Intimidation,
                Sniping = authoring.Sniping,
                Melee = authoring.Melee,
                Engineering = authoring.Engineering,
                Luck = authoring.Luck,
                Reputation = authoring.Reputation
            });
        }
    }
}
