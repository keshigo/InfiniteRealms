using Unity.Entities;
using Unity.Mathematics;

public struct UnitComponent : IComponentData
{
    public float Speed;
    public float3 Direction;
}
