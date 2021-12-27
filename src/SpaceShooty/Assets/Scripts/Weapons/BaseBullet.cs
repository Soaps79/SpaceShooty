using QGame;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BaseBullet : QScript
    {
        public float PushPower;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody != null)
            {
                var force = transform.position - other.transform.position;
                force.Normalize();
                other.attachedRigidbody.AddForce(-force * PushPower);
            }
        }
    }
}