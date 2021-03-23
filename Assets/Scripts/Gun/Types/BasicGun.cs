using System;
using System.Collections;
using System.Collections.Generic;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public abstract class BasicGun : MonoBehaviour, IGun
    {
        [SerializeField] private Vector3 localPositionOnPlayer;
        
        private PlayerShootHandler _playerShoot;

        [Inject]
        private void Construct(PlayerShootHandler playerShootHandler)
        {
            _playerShoot = playerShootHandler;
        }
        public abstract void Shoot();
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("touch");
            if (other.gameObject.CompareTag("Player"))
            {
                _playerShoot.SetGun(this);
                transform.SetParent(other.gameObject.transform);
                transform.localPosition = localPositionOnPlayer;
            }
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}