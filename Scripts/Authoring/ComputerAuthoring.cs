// Assets/Scripts/Authoring/ComputerAuthoring.cs
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ComputerAuthoring : MonoBehaviour
{
    /// <summary>
    /// ������, � ������� ����� ����� ������������������� � �����������
    /// </summary>
    public float InteractionRadius = 2f;
}

public class ComputerBaker : Baker<ComputerAuthoring>
{
    public override void Bake(ComputerAuthoring auth)
    {
        var e = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(e, new ComputerTag { Radius = auth.InteractionRadius });
        // ������� ��������� ������� � LocalTransform, ���� ��� �� ������:
        AddComponent(e, new LocalTransform
        {
            Position = auth.transform.position,
            Rotation = quaternion.identity,
            Scale = 1f
        });
    }
}

public struct ComputerTag : IComponentData
{
    /// <summary> ������ �������� ������� E� ������ ���������� </summary>
    public float Radius;
}
