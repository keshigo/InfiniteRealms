using Unity.Entities;
using UnityEngine;

public class TagUpperRealmAuthoring : MonoBehaviour
{
    class Baker : Baker<TagUpperRealmAuthoring>
    {
        public override void Bake(TagUpperRealmAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent<TagUpperRealm>(entity);
        }
    }
}
