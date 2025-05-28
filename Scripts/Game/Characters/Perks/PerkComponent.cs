// Scripts/Game/Characters/Perks/PerkComponent.cs
using Unity.Collections;
using Unity.Entities;

public struct PerkComponent : IComponentData
{
    public FixedList128Bytes<int> UnlockedPerks; // можно заменить на BitField или Enum-Flags
}

public struct PerkEffect : IComponentData
{
    public float DamageBonus;
    public float SpeedBonus;
    public float HealthBonus;
}
