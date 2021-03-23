using System;
using Isaac.Player;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class GunFactory : IGunFactory
    {
        private readonly Settings _settings;
        private readonly DiContainer _container;

        // самое время напрячься, но на данный момент фабрики хотят биндить все в контейнер  
        public GunFactory(DiContainer container,
            Settings settings)
        {
            _container = container;
            _settings = settings;
        }
        
        public GameObject Create(GunType type, Vector3 at)
        {
            GameObject obj;
            
            switch (type)
            {
                case GunType.DefaultGun: 
                    obj = _container.InstantiatePrefab(_settings.DefaultGun, at, Quaternion.identity, null);
                    break;
                
                default:
                    obj = null; 
                    break;
            }

            return obj;
        }
        
        [Serializable]
        public class Settings
        {
            public GameObject DefaultGun;
        }
    }
}