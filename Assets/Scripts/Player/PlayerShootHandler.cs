using Isaac.Gun;
using UnityEngine;

namespace Isaac.Player
{
    public class PlayerShootHandler
    {
        private BasicGun _playerBasicGun;

        public BasicGun Gun
        {
            get => _playerBasicGun;
            set => _playerBasicGun = value;
        }
        
        public void Shoot()
        {
            Debug.Log("Fire is ");
            Gun?.Shoot();
        }
    }
}