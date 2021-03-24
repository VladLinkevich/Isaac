using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Bullet
{
    public class BulletPool : IInitializable, IPool
    {
        private List<GameObject> _bullets;
        private int _bulletsCount;
        private GameObject _bulletsParent;
        
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
            _bulletsParent = GameObject.Instantiate(_settings.Bullets);
            AddedObjectInPool(_settings.BulletStartCount);
        }

        public GameObject GetObject()
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.activeInHierarchy == false)
                {
                    bullet.SetActive(true);
                    return bullet;
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
                _bullets.Add(bullet);
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
    }
}