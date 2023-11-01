using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TakeDamageVehicle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Vehicle currentVehicle = other.gameObject.GetComponent<Vehicle>();
            Vehicle collisionVehicle = this.gameObject.GetComponent<Vehicle>();
            Player player = other.gameObject.GetComponentInChildren<Player>();
            if (other.gameObject.name.Contains("CurrentVehicle"))
            {
                currentVehicle.Damage(5);
                if(collisionVehicle)
                {
                    collisionVehicle.Damage(5);
                }

                if (currentVehicle.vehicleHealth == 0)
                {
                    player.Damage(50);
                }
                
            }
        }
    }
}