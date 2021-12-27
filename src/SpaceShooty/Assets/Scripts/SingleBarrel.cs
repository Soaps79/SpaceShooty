using QGame;
using UnityEngine;

namespace Assets.Scripts
{
    public class SingleBarrel : QScript
    {
        public GameObject BulletPrefab;
        public GameObject ExitPoint;

        public float BulletSpeed;

        public float FireDelay;
        [SerializeField]
        private float _elapsedSinceFire;
        private bool _isInFireDelay;

        protected override void OnUpdate()
        {
            if (_isInFireDelay)
            {
                _elapsedSinceFire += Time.deltaTime;
                if (_elapsedSinceFire > FireDelay)
                    _isInFireDelay = false;
            }

            if (!_isInFireDelay && Input.GetMouseButton(0))
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            var bullet = GameObject.Instantiate(BulletPrefab, ExitPoint.transform.position, transform.rotation);
            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(transform.up * BulletSpeed);
            _isInFireDelay = true;
            _elapsedSinceFire = 0.0f;
        }
    }
}