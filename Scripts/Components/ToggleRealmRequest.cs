using Unity.Entities;

namespace InfiniteRealms.Components
{
    /// <summary>
    /// Добавляется тогда, когда игрок хочет переключить мир.
    /// После обработки системой автоматически удаляется.
    /// </summary>
    public struct ToggleRealmRequest : IComponentData { }
}
