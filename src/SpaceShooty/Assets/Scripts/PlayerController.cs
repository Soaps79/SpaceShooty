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
        public BaseGun WeaponOnePrefab;
        private BaseGun _currentWeapon;
        private ModifierApplicator _modifierApplicator;


        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            var go = GameObject.Instantiate(WeaponOnePrefab, transform);
            _currentWeapon = go.GetComponent<BaseGun>();
            _modifierApplicator = GetComponent<ModifierApplicator>();
            _modifierApplicator.Initialize(this, _currentWeapon);
        }

        public void ApplyModifier(FireSpeedModifier modifier)
        {
            modifier.ApplyAndBegin(_currentWeapon);
            modifier.transform.SetParent(transform);
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
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            var pickup = other.GetComponent<ModifierPickup>();
            if (pickup != null)
            {
                _modifierApplicator.ApplyModifier(pickup.ModifierPrefab);
                pickup.Consume();
            }
        }
    }
}
