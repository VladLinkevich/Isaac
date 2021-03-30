using UnityEngine;

namespace Isaac.Bullet
{
    public interface IPool
    {
        Bullet GetObject();
        void Destroy(Bullet bullet);
    }
}