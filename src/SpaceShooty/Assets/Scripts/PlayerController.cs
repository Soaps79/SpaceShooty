using System.Collections.Generic;
using Assets.Scripts.Powerups;
using Assets.Scripts.Weapons;
using QGame;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : QScript
    {
        private Rigidbody2D _rigidBody;
        public float Speed;
        private BaseGun _currentWeapon;
        private ModifierApplicator _modifierApplicator;

        private WeaponCaddy _weaponCaddy;
        public List<BaseGun> _startingWeapons;


        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _weaponCaddy = GetComponent<WeaponCaddy>();

            foreach (var weapon in _startingWeapons)
            {
                var gun = GameObject.Instantiate<BaseGun>(weapon, transform);
                _weaponCaddy.AddGun(gun);
            }

            // needs to be redone since caddy
            _modifierApplicator = GetComponent<ModifierApplicator>();
            _modifierApplicator.Initialize(this, _currentWeapon);
        }

        protected override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rigidBody.AddForce(new Vector2(0,1) * Speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rigidBody.AddForce(new Vector2(-1, 0) * Speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rigidBody.AddForce(new Vector2(0, -1) * Speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rigidBody.AddForce(new Vector2(1, 0) * Speed);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                _weaponCaddy.CycleNext();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _weaponCaddy.CyclePrevious();
            }
            
            if (Input.GetMouseButton(0))
            {
                _weaponCaddy.TryFireCurrentWeapon();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //var pickup = other.GetComponent<ModifierPickup>();
            //if (pickup != null)
            //{
            //    _modifierApplicator.ApplyModifier(pickup.ModifierPrefab);
            //    pickup.Consume();
            //}
        }
    }
}
