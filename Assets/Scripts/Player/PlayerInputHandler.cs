using System;
using UnityEngine;
using Zenject;

namespace Isaac.Player
{
    public class PlayerInputHandler : IFixedTickable
    {
        private readonly PlayerView _playerView;
        private readonly Settings _settings;

        public PlayerInputHandler(PlayerView playerView,
            Settings settings)
        {
            _playerView = playerView;
            _settings = settings;
        }

        public void FixedTick()
        {
            Vector3 movement = Vector3.zero;
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  movement += Vector3.left;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) movement += Vector3.right;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    movement += Vector3.forward;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  movement += Vector3.back;

            movement.Normalize();
            movement *= _settings.Speed;
            
            _playerView.SetMove(movement);
        }
        
        [Serializable]
        public class Settings
        {
            public float Speed;
        }
    }
}