using Unity.Entities;
using UnityEngine;

public class UnitAuthoring : MonoBehaviour
{
    public float Speed = 5f;
    public Vector3 Direction = Vector3.forward;
    public bool IsUpperRealm = true;

    class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new UnitComponent
            {
                Speed = authoring.Speed,
                Direction = authoring.Direction
            });

            if (authoring.IsUpperRealm)
                AddComponent<TagUpperRealm>(entity);
            else
                AddComponent<TagLowerRealm>(entity);
        }
    }
}
