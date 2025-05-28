using Unity.Entities;
using UnityEngine;

public class DistrictAuthoring : MonoBehaviour
{
    public DistrictType districtType;

    public class Baker : Baker<DistrictAuthoring>
    {
        public override void Bake(DistrictAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new DistrictComponent { Type = authoring.districtType });
        }
    }
}
