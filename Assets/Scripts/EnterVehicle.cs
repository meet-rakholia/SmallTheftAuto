using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnterVehicle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Player currentPLayer = other.GetComponent<Player>();
                currentPLayer.isInVehicle = true;
            }
        }
    }
}