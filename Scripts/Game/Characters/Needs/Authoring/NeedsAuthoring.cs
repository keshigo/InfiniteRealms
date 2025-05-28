using Unity.Entities;
using UnityEngine;
using InfiniteRealms.Needs.Components;

namespace InfiniteRealms.Needs.Authoring
{
    public class NeedsAuthoring : MonoBehaviour
    {
        public float Hunger = 100;
        public float Thirst = 100;
        public float Fun = 100;
        public float Social = 100;
        public float Bladder = 100;
        public float Hygiene = 100;
        public float Energy = 100;
    }

    public class NeedsBaker : Baker<NeedsAuthoring>
    {
        public override void Bake(NeedsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new NeedsComponent
            {
                Hunger = authoring.Hunger,
                Thirst = authoring.Thirst,
                Fun = authoring.Fun,
                Social = authoring.Social,
                Bladder = authoring.Bladder,
                Hygiene = authoring.Hygiene,
                Energy = authoring.Energy
            });
        }
    }
}
