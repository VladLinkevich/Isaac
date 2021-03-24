using UnityEngine;
using Zenject;

namespace Isaac.Player
{
    public class PlayerRotationHandler : IInitializable, ITickable
    {
        private readonly PlayerFacade _player;
        private Camera _camera;

        public PlayerRotationHandler(PlayerFacade player)
        {
            _player = player;
        }
    
        public void Initialize()
        {
            _camera = Camera.main;
        }
        
        public void Tick()
        {
            var dir = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            _player.Transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);
        }
    }
}