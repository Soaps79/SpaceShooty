using QGame;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Weapons
{
    [RequireComponent(typeof(Collider2D))]
    public class BaseBullet : QScript
    {
        private Collider2D _collider;
        public float PushPower;

        void Awake()
        {
            _collider = GetComponent<Collider2D>();
            //_collider.
        }

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