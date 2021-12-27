using Assets.Scripts.Weapons;

namespace Assets.Scripts.Powerups
{
    public abstract class GunModifier : ModifierBase
    {
        public override ModifierType ModifierType => ModifierType.Gun;
        public abstract void ApplyAndBegin(BaseGun baseGun);
    }
}