using QGame;

namespace Assets.Scripts.Powerups
{
    public class ModifierPickup : QScript
    {
        public ModifierBase ModifierPrefab;
        public void Consume()
        {
            Destroy(gameObject);
        }
    }
}