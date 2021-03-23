using UnityEngine;

namespace Isaac.Bullet
{
    public interface IPool
    {
        GameObject GetObject();
        void Destroy(GameObject bullet);
    }
}