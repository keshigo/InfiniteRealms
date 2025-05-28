using InfiniteRealms.Components;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class RealmSwitchButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        var entity = PlayerEntityReference.Instance;
        var em = World.DefaultGameObjectInjectionWorld.EntityManager;

        if (!em.HasComponent<ToggleRealmRequest>(entity))
        {
            em.AddComponent<ToggleRealmRequest>(entity);
        }
    }
}
