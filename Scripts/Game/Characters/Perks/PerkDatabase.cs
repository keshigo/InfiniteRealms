// Scripts/Game/Characters/Perks/PerkDatabase.cs
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkDatabase", menuName = "RPG/PerkDatabase")]
public class PerkDatabase : ScriptableObject
{
    public List<PerkData> allPerks;

    public List<PerkData> GetAllPerks() => allPerks;
}

// Scripts/Game/Characters/Perks/PerkData.cs
[System.Serializable]
public class PerkData
{
    public string Name;
    public string Description;
    public float DamageBonus;
    public float SpeedBonus;
    public float HealthBonus;
    public List<string> RequiredPerkIDs;
    public string ID;
}
