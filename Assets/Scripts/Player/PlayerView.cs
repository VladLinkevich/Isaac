using UnityEngine;

namespace Isaac.Player
{
    public class PlayerView
    {
        private readonly CharacterController _characterController;

        public PlayerView(CharacterController characterController)
        {
            _characterController = characterController;
        }

        public void SetMove(Vector3 movement)
        {
            _characterController.Move(movement);
        }
    }
}
