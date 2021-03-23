using UnityEngine;

namespace Isaac.Gun
{
    public class Pistol : BasicGun
    {
        public override void Shoot()
        {
            Debug.Log($"pow pow");
        }
    }
}