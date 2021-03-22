using Isaac.Gun;
using UnityEngine;

namespace Isaac.Player
{
    public class PlayerShootHandler
    {
        private IGun _playerGun;
        private IGun _gun;

        public PlayerShootHandler(IGun gun)
        {
            _gun = gun;
        }

        public IGun Gun
        {
            get => _playerGun;
            private set => _playerGun = value;
        }

        public void SetGunTrigger()
        {
            if (_gun != null)
                Gun = _gun;
        }
        public void Shoot()
        {
            Debug.Log("Fire is ");
            Gun?.Shoot();
        }
    }
}