// Scripts/City/Components/CityDistrict.cs
using Unity.Entities;
using Unity.Mathematics;

public struct CityDistrict : IComponentData
{
    public DistrictType Type;
    public int2 Position; // ���������� ������ ������
    public int2 Size;     // ������ � ������ ������
}
