using System;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class DefaultGun : BasicGun
    {
        public override void Shoot(Transform at)
        {
            Debug.Log($"piu piu");
            base.Shoot(at);
        }
    }
}