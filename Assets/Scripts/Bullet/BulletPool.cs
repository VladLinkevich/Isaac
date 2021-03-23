using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Bullet
{
    public class BulletPool : IInitializable, IPool
    {
        private List<GameObject> _bullets;
        private int bulletsCount;

        private readonly IBulletFactory _factory;
        private readonly Settings _settings;

        public BulletPool(IBulletFactory factory,
            Settings settings)
        {
            _factory = factory;
            _settings = settings;

            _bullets = new List<GameObject>();
        }
        
        public void Initialize()
        {
            GameObject bullets = GameObject.Instantiate(_settings.Bullets);
            bulletsCount = _settings.BulletStartCount;
            
            for (int i = 0, end = bulletsCount; i < end; ++i)
            {
                var bullet = _factory.Create();
                bullet.transform.parent = bullets.transform;
                _bullets.Add(bullet);
            }
        }

        public GameObject GetObject()
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.activeInHierarchy == true)
                {
                    bullet.SetActive(true);
                    return bullet;
                }
            }

            return null;
        }

        public void Destroy(GameObject bullet)
        {
            bullet.SetActive(false);
        }
        
        [Serializable]
        public class Settings
        {
            public int BulletStartCount;
            public GameObject Bullets;
        }
    }
}