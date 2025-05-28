// Scripts/City/Authoring/BuildingAuthoring.cs
using UnityEngine;
using Unity.Entities;

public class BuildingAuthoring : MonoBehaviour
{
    public BuildingType Type;
    public BuildingQuality Quality;
}

public class BuildingAuthoringBaker : Baker<BuildingAuthoring>
{
    public override void Bake(BuildingAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Renderable);
        AddComponent(entity, new Building
        {
            Type = authoring.Type,
            Quality = authoring.Quality,
            Position = int2.zero
        });
    }
}
