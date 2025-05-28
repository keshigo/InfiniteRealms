using Unity.Entities;

public struct GainedExperience : IComponentData
{
    public ExperienceType Type;
    public float Amount;
}

public enum ExperienceType : byte
{
    Strength,
    Dexterity,
    Endurance,
    Charisma,
    Intimidation,
    Sniping,
    Melee,
    Engineering,
    General
}
