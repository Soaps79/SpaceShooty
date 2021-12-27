using Assets.Scripts.Weapons;

namespace Assets.Scripts.Powerups
{
    public class FireSpeedModifier : GunModifier
    {
        public float FireRateIncreasePercentage;
        public float Duration;

        public override void ApplyAndBegin(BaseGun baseGun)
        {
            baseGun.AddFireDelayModifier(FireRateIncreasePercentage);
            StopWatch.AddNode("t", Duration, true).OnTick += () =>
            {
                baseGun.AddFireDelayModifier(-FireRateIncreasePercentage);
                Destroy(gameObject);
            };
        }
    }
}