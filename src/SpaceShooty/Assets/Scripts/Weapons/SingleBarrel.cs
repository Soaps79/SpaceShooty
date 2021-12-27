using Assets.Scripts.Weapons;
using QGame;
using UnityEngine;

namespace Assets.Scripts
{
    public class SingleBarrel : BaseGun
    {
        public GameObject BulletPrefab;
        public GameObject ExitPoint;
        public float BulletSpeed;
        
        protected override  void Fire()
        {
            var bullet = GameObject.Instantiate(BulletPrefab, ExitPoint.transform.position, transform.rotation);
            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(transform.up * BulletSpeed);
        }
    }
}