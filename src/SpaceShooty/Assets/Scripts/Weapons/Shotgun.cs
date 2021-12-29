using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Weapons
{
    public class Shotgun : BaseGun
    {
        public GameObject PelletPrefab;
        public GameObject ExitPoint;

        public float SprayArc;
        public int PelletCount;
        public float PelletLifetime;
        public float MinSpeed;
        public float MaxSpeed;

        protected override void Fire()
        {
            var exitPos = ExitPoint.transform.position;
            var delta = SprayArc / PelletCount;
            var start = 0 - delta * (PelletCount / 2);

            for (var i = 0; i < PelletCount; i++)
            {
                var angleOffset = start + delta * i;
                var angleOffsetVector = new Vector3(0, 0, angleOffset);
                var pellet = GameObject.Instantiate(PelletPrefab, exitPos, transform.rotation);
                pellet.transform.Rotate(angleOffsetVector);

                var rigidBody = pellet.GetComponent<Rigidbody2D>();
                rigidBody.AddForce(pellet.transform.up * GetSpeed());

                var destroyTimer = pellet.GetComponent<DestroyTimer>();
                destroyTimer.SetLifetime(PelletLifetime);
            }
        }

        private float GetSpeed()
        {
            return Random.Range(MinSpeed, MaxSpeed);
        }
    }
}