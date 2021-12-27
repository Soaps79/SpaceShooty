using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts
{
    public class DoubleBarrel : BaseGun
    {
        public GameObject BulletPrefab;
        public GameObject BarrelOneExit;
        public GameObject BarrelTwoExit;
        public float BulletSpeed;

        protected override void Fire()
        {
            var bullet = GameObject.Instantiate(BulletPrefab, BarrelOneExit.transform.position, transform.rotation);
            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(transform.up * BulletSpeed);

            bullet = GameObject.Instantiate(BulletPrefab, BarrelTwoExit.transform.position, transform.rotation);
            rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(transform.up * BulletSpeed);
        }
    }
}