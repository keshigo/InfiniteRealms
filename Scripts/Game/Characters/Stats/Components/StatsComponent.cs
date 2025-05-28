using Unity.Entities;

namespace InfiniteRealms.Stats.Components
{
    public struct StatsComponent : IComponentData
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
}
