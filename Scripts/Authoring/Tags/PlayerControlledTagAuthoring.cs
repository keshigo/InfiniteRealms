using Unity.Entities;
using UnityEngine;

public class PlayerControlledTagAuthoring : MonoBehaviour
{
    class Baker : Baker<PlayerControlledTagAuthoring>
    {
        public override void Bake(PlayerControlledTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent<PlayerControlledTag>(entity);
        }
    }
}
