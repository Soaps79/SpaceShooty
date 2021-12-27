using System;
using Assets.Scripts.Weapons;
using QGame;
using UnityEngine;

namespace Assets.Scripts.Powerups
{
    public class ModifierApplicator : QScript
    {
        private PlayerController _playerController;
        private BaseGun _baseGun;

        public void Initialize(PlayerController playerController, BaseGun baseGun)
        {
            _playerController = playerController;
            _baseGun = baseGun;
        }

        public void ApplyModifier(ModifierBase modifierPrefab)
        {
            var modifier = GameObject.Instantiate(modifierPrefab, transform);

            switch (modifier.ModifierType)
            {
                case ModifierType.None:
                    throw new UnityException("Attempted to apply Modifier with type None");
                case ModifierType.Gun:
                    var gunModifier = modifier as GunModifier;
                    if(gunModifier == null)
                        throw new UnityException("Modifier was marked Gun when it was not Gun");
                    gunModifier.ApplyAndBegin(_baseGun);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}