using Unity.Entities;
using Unity.Mathematics;

public struct MoveSpeed : IComponentData
{
    public float Value;
}

public struct PlayerControlledTag : IComponentData { }
