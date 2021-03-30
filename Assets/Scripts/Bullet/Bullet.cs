using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private BulletPool _bulletPool;

        private Vector3 _offsetOnStep;
        private float _lifeTime;
        private float _startTime;

        [Inject]
        public void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
        
        // еще один переменная из Gun и передаю сюда сам Gun
        public void StartShooting(Vector3 position, Quaternion rotation, float speed, float lifeTime)
        {
            gameObject.SetActive(true);

            transform.position = position;
            transform.rotation = rotation;
            _lifeTime = lifeTime;
            
            _offsetOnStep = new Vector3(Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad),
                0,
                - Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad));

            _offsetOnStep *= speed;
            
            _rigidbody.velocity = _offsetOnStep;
            _startTime = Time.realtimeSinceStartup;
        }

        private void FixedUpdate()
        {
            if (Time.realtimeSinceStartup - _startTime > _lifeTime)
            {
                Destroy();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit");
           Destroy();
        }

        private void Destroy()
        {
            _bulletPool.Destroy(this);
            gameObject.SetActive(false);
        }
    }
}