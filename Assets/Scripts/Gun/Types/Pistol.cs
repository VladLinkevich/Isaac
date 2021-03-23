using System;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class Pistol : BasicGun
    {
        public override void Shoot(Transform at)
        {
            Debug.Log($"pow pow");
            base.Shoot(at);
        }
    }
}