using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Enemy
{
    public class EnemyFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public Vector3 Position
        {
            get => gameObject.transform.position;
            set => gameObject.transform.position = value;
        }
        
        public void OnDespawned()
        {
            throw new NotImplementedException();
        }

        public void OnSpawned(IMemoryPool p1)
        {
            //throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        public class Factory : PlaceholderFactory<EnemyFacade>
        {
        }
    }
}
