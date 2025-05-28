using Unity.Entities;

public struct ExperienceComponent : IComponentData
{
    public float StrengthXP;
    public float DexterityXP;
    public float EnduranceXP;

    public float CharismaXP;
    public float IntimidationXP;

    public float SnipingXP;
    public float MeleeXP;
    public float EngineeringXP;

    public float GeneralXP; // Общий уровень, если понадобится
}
