using System;
using System.Collections;
using System.Collections.Generic;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class BasicGun : MonoBehaviour
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
                _playerShoot.Gun = this;
            }
        }
        
        public void Shoot()
        {
            Debug.Log($"Default shoot");
        }
        
    }
}