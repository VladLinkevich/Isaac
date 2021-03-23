using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isaac.Bullet
{
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }
    }
}