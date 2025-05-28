// Scripts/City/Systems/CityGenerationSystem.cs
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class CityGenerationSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<BeginInitializationEntityCommandBufferSystem.Singleton>();
    }

    protected override void OnUpdate()
    {
        var ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>()
                           .CreateCommandBuffer(World.Unmanaged);

        // Примерная карта: 3 района: бедный, средний, богатый
        GenerateDistrict(new int2(0, 0), new int2(50, 50), DistrictType.Poor, ecb);
        GenerateDistrict(new int2(60, 0), new int2(50, 50), DistrictType.Middle, ecb);
        GenerateDistrict(new int2(120, 0), new int2(50, 50), DistrictType.Rich, ecb);

        Enabled = false; // Однократная генерация
    }

    private void GenerateDistrict(int2 position, int2 size, DistrictType type, EntityCommandBuffer ecb)
    {
        var entity = ecb.CreateEntity();
        ecb.AddComponent(entity, new CityDistrict
        {
            Type = type,
            Position = position,
            Size = size
        });

        int buildingCount = 20;

        for (int i = 0; i < buildingCount; i++)
        {
            int2 pos = position + new int2(UnityEngine.Random.Range(0, size.x), UnityEngine.Random.Range(0, size.y));
            CreateBuilding(pos, type, ecb);
        }
    }

    private void CreateBuilding(int2 position, DistrictType districtType, EntityCommandBuffer ecb)
    {
        var buildingEntity = ecb.CreateEntity();

        var (type, quality) = GetBuildingTypeAndQuality(districtType);

        ecb.AddComponent(buildingEntity, new Building
        {
            Position = position,
            Type = type,
            Quality = quality
        });
    }
    private (BuildingType, BuildingQuality) GetBuildingTypeAndQuality(DistrictType districtType)
    {
        BuildingType type;
        BuildingQuality quality;

        switch (districtType)
        {
            case DistrictType.Poor:
                type = GetRandomFrom(BuildingType.Residential, BuildingType.Restaurant, BuildingType.Supermarket);
                quality = BuildingQuality.Low;
                break;
            case DistrictType.Middle:
                type = GetRandomFrom(BuildingType.Residential, BuildingType.Supermarket, BuildingType.JobOffice, BuildingType.FurnitureStore, BuildingType.ElectronicsStore);
                quality = BuildingQuality.Medium;
                break;
            case DistrictType.Rich:
                type = GetRandomFrom(BuildingType.CarDealer, BuildingType.Residential, BuildingType.Restaurant, BuildingType.FurnitureStore, BuildingType.ElectronicsStore);
                quality = BuildingQuality.High;
                break;
            default:
                type = BuildingType.Residential;
                quality = BuildingQuality.Low;
                break;
        }

        return (type, quality);
    }

    private BuildingType GetRandomFrom(params BuildingType[] types)
    {
        return types[UnityEngine.Random.Range(0, types.Length)];
    }


}
