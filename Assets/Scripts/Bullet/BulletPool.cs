using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Bullet
{
    public class BulletPool : IInitializable, IPool
    {
        private readonly List<Pool> _bullets;
        private int _bulletsCount;
        private GameObject _bulletsParent;
        
        private readonly IBulletFactory _factory;
        private readonly Settings _settings;

        public BulletPool(IBulletFactory factory,
            Settings settings)
        {
            _factory = factory;
            _settings = settings;

            _bullets = new List<Pool>();
        }
        
        public void Initialize()
        {
            _bulletsParent = GameObject.Instantiate(_settings.Bullets);
            AddedObjectInPool(_settings.BulletStartCount);
        }
        
        public Bullet GetObject()
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.IsActive == false)
                {
                    bullet.IsActive = true;
                    return bullet.Bullet;
                }
            }

            AddedObjectInPool(_settings.BulletStartCount);
            
            return GetObject();
        }

        private void AddedObjectInPool(int count)
        {
            _bulletsCount += count;
            
            for (int i = 0, end = count; i < end; ++i)
            {
                var bullet = _factory.Create();
                bullet.transform.parent = _bulletsParent.transform;
                _bullets.Add(new Pool(bullet, false));
            }
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
        
        public class Pool
        {
            public Bullet Bullet;
            public bool IsActive;

            public Pool(Bullet bullet, bool isActive)
            {
                Bullet = bullet;
                IsActive = isActive;
            }
        }
    }
}