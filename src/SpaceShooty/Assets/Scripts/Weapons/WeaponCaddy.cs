using System.Collections.Generic;
using QGame;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponCaddy : QScript
    {
        [SerializeField]
        private List<BaseGun> _gunArray;

        private int _currentIndex;

        public void AddGun(BaseGun gun)
        {
            _gunArray.Add(gun);
            if(_gunArray.Count > 1)
                CycleNext();
        }

        public void TryFireCurrentWeapon()
        {
            _gunArray[_currentIndex].TryFire();
        }

        public void CycleNext()
        {
            Debug.Log("cycle next weapon");
            if (_gunArray.Count <= 1) return;

            DeactivateCurrentWeapon();

            if (_currentIndex == _gunArray.Count - 1)
                _currentIndex = 0;
            else
                _currentIndex++;

            _gunArray[_currentIndex].gameObject.SetActive(true);
        }
        
        public void CyclePrevious()
        {
            Debug.Log("cycle previous weapon");
            if (_gunArray.Count <= 1) return;

            DeactivateCurrentWeapon();

            if (_currentIndex == 0)
                _currentIndex = _gunArray.Count;
            else
                _currentIndex--;

            _gunArray[_currentIndex].gameObject.SetActive(true);
        }

        private void DeactivateCurrentWeapon()
        {
            _gunArray[_currentIndex].ShutDown();
            _gunArray[_currentIndex].gameObject.SetActive(false);
        }
    }
}