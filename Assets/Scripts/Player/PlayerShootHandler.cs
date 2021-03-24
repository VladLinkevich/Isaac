using Isaac.Gun;
using UnityEngine;

namespace Isaac.Player
{
    public class PlayerShootHandler
    {
        private IGun _playerBasicGun;
        
        private readonly PlayerFacade _player;

        public PlayerShootHandler(PlayerFacade player)
        {
            _player = player;
        }
        
        public IGun Gun
        {
            get => _playerBasicGun;
            private set => _playerBasicGun = value;
        }

        public void SetGun(BasicGun gun)
        {
            Gun?.Throw();
            
            Gun = gun;
        }
        
        // тут мы не производим выстрел, а просто просим чтобы оружее выстрелило 
        // за выстрел отвечает сам gun
        public void Shoot()
        {
            Gun?.Shoot(_player.Transform);
        }
    }
}