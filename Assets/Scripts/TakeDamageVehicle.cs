using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TakeDamageVehicle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Vehicle collisionVehicle = other.gameObject.GetComponent<Vehicle>();
            Vehicle currentVehicle = this.gameObject.GetComponent<Vehicle>();
            Player player = this.gameObject.GetComponentInChildren<Player>();
            if (other.gameObject.name.Contains("Vehicle") || other.gameObject.name.Contains("Building"))
            {
                currentVehicle.Damage(5);
                if(collisionVehicle)
                {
                    collisionVehicle.Damage(5);
                }

                if (currentVehicle.vehicleHealth == 0)
                {
                    if (player)
                    {
                        player.Damage(50);
                    }
                }
                
            }
        }
    }
}