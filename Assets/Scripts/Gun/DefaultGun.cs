using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isaac.Gun
{
    public class DefaultGun : MonoBehaviour, IGun
    {
        public void Shoot()
        {
            Debug.Log($"Default shoot");
        }
        
    }
}