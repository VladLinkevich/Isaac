using UnityEngine;

namespace Isaac.Gun
{
    public class DefaultGun : BasicGun
    {
        public override void Shoot()
        {
            Debug.Log($"piu piu");
        }
    }
}