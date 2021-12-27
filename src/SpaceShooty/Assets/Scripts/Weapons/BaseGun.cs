using System;
using System.Collections.Generic;
using QGame;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class BaseGun : QScript
    {
        public float BaseFireDelay;
        [SerializeField] private float _currentFireDelay;
        [SerializeField] private float _currentFireDelayModifier;
        [SerializeField] private float _elapsedSinceFire;
        private bool _isInFireDelay;

        void Awake() { RecalcFireDelay(); }

        protected override void OnUpdate()
        {
            if (_isInFireDelay)
            {
                _elapsedSinceFire += Time.deltaTime;
                if (_elapsedSinceFire > _currentFireDelay)
                    _isInFireDelay = false;
            }

            if (!_isInFireDelay && Input.GetMouseButton(0))
            {
                Fire();
                CompleteFire();
            }
        }

        public void AddFireDelayModifier(float amount)
        {
            _currentFireDelayModifier += amount;
            RecalcFireDelay();
        }

        private void RecalcFireDelay()
        {
            _currentFireDelay = Math.Max(0, BaseFireDelay - (BaseFireDelay * _currentFireDelayModifier));
        }

        protected abstract void Fire();

        private void CompleteFire()
        {
            _isInFireDelay = true;
            _elapsedSinceFire = 0.0f;
        }
    }
}