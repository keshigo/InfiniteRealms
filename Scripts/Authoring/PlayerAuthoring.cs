using Unity.Entities;
using UnityEngine;

namespace InfiniteRealms.Authoring
{
    public class PlayerAuthoring : MonoBehaviour
    {
        [Min(0)] public float MoveSpeed = 5f;
    }

    public class PlayerBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring auth)
        {
            var e = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(e, new MoveSpeed { Value = auth.MoveSpeed });
            AddComponent<PlayerControlledTag>(e);
            AddComponent<TagUpperRealm>(e);

            // Сохраняем ссылку на игрока
            PlayerEntityReference.Instance = e;
        }
    }
}
