using Unity.Entities;
using Unity.Mathematics;

namespace InfiniteRealms.Stats
{
    public struct ExperienceComponent : IComponentData
    {
        public int CharismaXP;
        public int CookingXP;
        public int ShootingXP;
        public int DrivingXP;

        public int CharismaLevel;
        public int CookingLevel;
        public int ShootingLevel;
        public int DrivingLevel;
    }
}
