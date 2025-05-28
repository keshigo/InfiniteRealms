using Unity.Entities;

public struct LevelComponent : IComponentData
{
    public int Level;
    public int Experience;
    public int ExperienceToNextLevel;
    public int AvailablePerkPoints;
}
