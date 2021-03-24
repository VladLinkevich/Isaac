using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Isaac.Gun
{
    public class DefaultGun : BasicGun
    {
        public override void Shoot(Transform at)
        {
            base.Shoot(at);
        }

        public override void Fire(Transform at)
        {
            base.Fire(at);
        }
    }
}