using Isaac.Gun;
using UnityEngine;

namespace Isaac.Player
{
    public class PlayerShootHandler
    {
        private BasicGun _playerBasicGun;
        
        private readonly PlayerFacade _player;

        private float _lastShootTime;

        public PlayerShootHandler(PlayerFacade player)
        {
            _player = player;
        }
        
        public BasicGun Gun
        {
            get => _playerBasicGun;
            private set => _playerBasicGun = value;
        }

        public void SetGun(BasicGun gun)
        {
            if (Gun == true)
                Gun.Destroy();
            
            Gun = gun;
        }
        
        public void Shoot()
        {
            if (Gun == true)
            {
                if (Time.realtimeSinceStartup - _lastShootTime > Gun.MaxShootDelay)
                {
                    _lastShootTime = Time.realtimeSinceStartup;
                    Gun.Shoot(_player.Transform);
                }
            }
        }
    }
}