using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isaac.Player
{
    public class PlayerFacade : MonoBehaviour
    {
        [Inject]
        private void Construct()
        {
        }
    }
}