// Scripts/City/Components/CityDistrict.cs
using Unity.Entities;
using Unity.Mathematics;

public struct CityDistrict : IComponentData
{
    public DistrictType Type;
    public int2 Position; // Координаты центра района
    public int2 Size;     // Ширина и высота района
}
