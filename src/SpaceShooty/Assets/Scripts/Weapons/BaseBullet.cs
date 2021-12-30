using QGame;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BaseBullet : QScript
    {
        public float PushPower;
        public bool DestroyOnContact;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody == null) return;

            var force = other.transform.position - transform.position;
            force.Normalize();
            other.attachedRigidbody.AddForce(force * PushPower);

            if(DestroyOnContact)
                Destroy(gameObject);
        }
    }
}