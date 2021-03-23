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
                Gun.Shoot();
        }
    }
}