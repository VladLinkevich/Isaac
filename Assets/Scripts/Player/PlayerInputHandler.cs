using UnityEngine;
using Zenject;

namespace Isaac.Player
{
    public class PlayerInputHandler : IFixedTickable
    {
        private readonly PlayerView _playerView;

        public PlayerInputHandler(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void FixedTick()
        {
            if (Input.GetKey(KeyCode.A)) _playerView.SetMove(Vector3.left);
        }
    }
}