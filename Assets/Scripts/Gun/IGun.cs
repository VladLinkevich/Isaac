using UnityEngine;

namespace Isaac.Gun
{
    public interface IGun
    {
        void Shoot(Transform at);
        void Throw();
    }
}