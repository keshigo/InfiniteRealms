using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.InputSystem;

[BurstCompile]
// ������� ����������: �� ��������� �������, ���� ��� ��������� � ������� ������������
[RequireMatchingQueriesForUpdate]
public partial struct PlayerMovementSystem : ISystem
{
    // OnCreate ����� �������� ������, ��� ����� ������
    public void OnCreate(ref SystemState state) { }

    public void OnUpdate(ref SystemState state)
    {
        float dt = SystemAPI.Time.DeltaTime;

        // 1) �������� WASD-����
        float2 input = float2.zero;
        var kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.wKey.isPressed) input.y += 1;
            if (kb.sKey.isPressed) input.y -= 1;
            if (kb.aKey.isPressed) input.x -= 1;
            if (kb.dKey.isPressed) input.x += 1;
        }

        if (math.lengthsq(input) < 0.0001f)
            return;

        float2 dir = math.normalize(input);

        // 2) �������� �� ���� ������� (� ����� + MoveSpeed + Transform)
        foreach (var (tx, speed) in
                 SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>()
         .WithAll<PlayerControlledTag, TagLowerRealm>())
        {
            // speed.ValueRO.Value � ��� ���� �������� �� Baker��
            float3 delta = new float3(dir.x, 0, dir.y)
                           * speed.ValueRO.Value
                           * dt;
            tx.ValueRW.Position += delta;
        }
    }

    // OnDestroy ����� ���� �� �������������
    public void OnDestroy(ref SystemState state) { }
}
