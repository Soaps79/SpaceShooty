using QGame;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class BaseGun : QScript
    {
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
                Fire();
                CompleteFire();
            }
        }

        protected abstract void Fire();

        private void CompleteFire()
        {
            _isInFireDelay = true;
            _elapsedSinceFire = 0.0f;
        }
    }
}