using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class GunSpawner : IInitializable
    {
        private readonly IGunFactory _factory;

        public GunSpawner(IGunFactory factory)
        {
            _factory = factory;
        } 
        
        public void Initialize()
        {
            _factory.Create(GunType.DefaultGun, new Vector3(5f, 0f, 5f));
            _factory.Create(GunType.Pistol, new Vector3(-5f, 0f, 5f));
        }
    }
}