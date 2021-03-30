using UnityEngine;

namespace Isaac.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;

        public void Move(Vector3 movement)
        {
            _character.Move(movement);
        }
    }
}