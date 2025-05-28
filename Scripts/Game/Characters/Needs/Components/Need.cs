using Unity.Entities;

public struct Need : IComponentData
{
    public float Hunger;
    public float Hygiene;
    public float Fun;
    public float Social;
    public float Bladder;
    public float Energy;

    public float HungerTimer;
    public float HygieneTimer;
    public float FunTimer;
    public float SocialTimer;
    public float BladderTimer;
    public float EnergyTimer;
}
