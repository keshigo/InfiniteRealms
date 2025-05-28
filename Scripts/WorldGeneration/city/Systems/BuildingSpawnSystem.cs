// Scripts/City/Systems/BuildingSpawnSystem.cs
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;

public partial class BuildingSpawnSystem : SystemBase
{
    private Dictionary<(BuildingType, BuildingQuality), GameObject> _prefabMap;

    protected override void OnCreate()
    {
        RequireForUpdate<Building>();
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        _prefabMap = new Dictionary<(BuildingType, BuildingQuality), GameObject>();

        foreach (BuildingType type in System.Enum.GetValues(typeof(BuildingType)))
        {
            foreach (BuildingQuality quality in System.Enum.GetValues(typeof(BuildingQuality)))
            {
                string path = $"Buildings/{type}_{quality}";
                var prefab = Resources.Load<GameObject>(path);
                if (prefab != null)
                {
                    _prefabMap[(type, quality)] = prefab;
                }
                else
                {
                    Debug.LogWarning($"Missing prefab at path: {path}");
                }
            }
        }
    }

    protected override void OnUpdate()
    {
        Entities
            .WithNone<SpawnedTag>() // не спавнили ещё
            .ForEach((Entity entity, in Building building) =>
            {
                if (_prefabMap.TryGetValue((building.Type, building.Quality), out var prefab))
                {
                    var worldPos = new float3(building.Position.x, 0, building.Position.y);
                    Object.Instantiate(prefab, worldPos, quaternion.identity);
                }

                EntityManager.AddComponent<SpawnedTag>(entity);
            }).WithoutBurst().Run();
    }
}

public struct SpawnedTag : IComponentData { }
