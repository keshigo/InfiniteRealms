using Unity.Entities;
using UnityEngine;

public class TagLowerRealmAuthoring : MonoBehaviour
{
    class Baker : Baker<TagLowerRealmAuthoring>
    {
        public override void Bake(TagLowerRealmAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent<TagLowerRealm>(entity);
        }
    }
}

