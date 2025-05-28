// Scripts/Game/Characters/Stats/PlayerStats.cs
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int Level;
    public int SkillPoints;
    public List<string> UnlockedPerks;

    private void Awake() => Instance = this;

    public bool CanUnlock(PerkData perk) =>
        SkillPoints > 0 &&
        perk.RequiredPerkIDs.All(id => UnlockedPerks.Contains(id)) &&
        !UnlockedPerks.Contains(perk.ID);

    public void Unlock(PerkData perk)
    {
        SkillPoints--;
        UnlockedPerks.Add(perk.ID);
        // Добавить эффект на игрока — см. ApplyPerkEffectsSystem
    }
}
