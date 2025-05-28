using Unity.Entities;

public struct NeedDecayConfig : IComponentData
{
    public float HungerDecayInterval;
    public float HygieneDecayInterval;
    public float FunDecayInterval;
    public float SocialDecayInterval;
    public float BladderDecayInterval;
    public float EnergyDecayInterval;

    public float DecayAmount;
}
