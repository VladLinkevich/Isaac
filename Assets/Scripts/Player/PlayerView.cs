using UnityEngine;
using Zenject;
using System;

namespace Isaac.Player
{
    public class PlayerView
    {

        private readonly CharacterController _characterController;
        private readonly Settings _settings;

        private float _health;
        private bool _isDead;

        [Inject]
        public PlayerView(CharacterController characterController,
            Settings settings)
        {
            _characterController = characterController;
            _settings = settings;

            _health = _settings.PlayerHealth;
        }

        public float Health
        {
            get => _health;
            set => _health = value;
        }

        public bool IsDead
        {
            get => _isDead;
            set => _isDead = value;
        }

        public void SetMove(Vector3 movement)
        {
            _characterController.Move(movement);
        }

        [Serializable]
        public class Settings
        {
            public float PlayerHealth;
        }
    }
}
