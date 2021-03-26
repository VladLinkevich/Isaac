using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        
        private BulletPool _bulletPool;

        private float _offsetX;
        private float _offsetY;
        
        [Inject]
        public void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
        
        public void StartShooting(Vector3 position, Quaternion rotation)
        {
            gameObject.SetActive(true);

            transform.position = position;
            transform.rotation = rotation;
            
            _offsetX = Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            _offsetY = - Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        }

        private void FixedUpdate()
        {
            _controller.Move(new Vector3(_offsetX,0,_offsetY));
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit");
            _bulletPool.Destroy(gameObject);
        }
    }
}