using Unity.Entities;

namespace InfiniteRealms.Needs.Components
{
    public struct NeedsComponent : IComponentData
    {
        public float Hunger;
        public float Thirst;
        public float Fun;
        public float Social;
        public float Bladder;
        public float Hygiene;
        public float Energy;
    }
}
