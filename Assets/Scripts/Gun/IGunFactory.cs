using UnityEngine;

namespace Isaac.Gun
{
    public interface IGunFactory
    {
        GameObject Create(GunType type, Vector3 at);
    }
}