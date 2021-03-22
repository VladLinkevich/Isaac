using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class DetectPlayer : MonoBehaviour
    {
        private PlayerShootHandler _playerShoot;

        [Inject]
        private void Construct(PlayerShootHandler playerShootHandler)
        {
            _playerShoot = playerShootHandler;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("touch");
            if (other.gameObject.CompareTag("Player"))
            {
                _playerShoot.SetGunTrigger();
            }
        }
    }
}
