using QGame;

namespace Assets.Scripts.Powerups
{
    public abstract class ModifierBase : QScript
    {
        public abstract ModifierType ModifierType { get; }
    }
}