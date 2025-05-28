// Scripts/UI/PerkTree/PerkTreeUI.cs
using UnityEngine;

public class PerkTreeUI : MonoBehaviour
{
    public GameObject perkButtonPrefab;
    public Transform perkContainer;

    private void Start()
    {
        var perks = PerkDatabase.Instance.GetAllPerks(); // Предположим, есть база перков
        foreach (var perk in perks)
        {
            var btn = Instantiate(perkButtonPrefab, perkContainer);
            btn.GetComponentInChildren<Text>().text = perk.Name;
            btn.GetComponent<Button>().onClick.AddListener(() => OnPerkSelected(perk));
        }
    }

    private void OnPerkSelected(PerkData perk)
    {
        if (PlayerStats.Instance.CanUnlock(perk))
        {
            PlayerStats.Instance.Unlock(perk);
        }
    }
}
