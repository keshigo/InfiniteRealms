using InfiniteRealms.Authoring;
using Unity.Entities;
using UnityEngine;

public class PlayerBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        PlayerEntityReference.Instance = entity;

    }

}
