using QGame;

namespace Assets.Scripts
{
    // usage is wonky af, fix me when more use cases
    public class DestroyTimer : QScript
    {
        public float Lifetime;

        void Awake()
        {
            if (Lifetime != 0.0f)
            {
                StartTimer();
            }
        }

        public void SetLifetime(float lifetime)
        {
            Lifetime = lifetime;
            StartTimer();
        }

        public void StartTimer()
        {
            StopWatch.AddNode("t", Lifetime).OnTick += () => { Destroy(gameObject); };
        }
    }
}