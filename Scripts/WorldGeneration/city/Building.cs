// Scripts/City/Components/Building.cs
using Unity.Entities;
using Unity.Mathematics;

public struct Building : IComponentData
{
    public BuildingType Type;
    public BuildingQuality Quality;
    public int2 Position;
}
