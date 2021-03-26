using UnityEngine;

namespace Isaac.Bullet
{
    public interface IPool
    {
        Bullet GetObject();
        void Destroy(GameObject bullet);
    }
}