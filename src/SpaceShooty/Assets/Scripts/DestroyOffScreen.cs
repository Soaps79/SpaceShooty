using QGame;

namespace Assets.Scripts
{
    public class DestroyOffScreen : QScript
    {
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}