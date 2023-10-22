using System;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnterVehicle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Player currentPlayer = other.GetComponent<Player>();
            if (other.gameObject.name == "Player" && !currentPlayer.isInVehicle)
            {
                GameObject vehicle = this.transform.parent.gameObject;
                BoxCollider2D boxCollider2D = other.GetComponent<BoxCollider2D>();
                SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
                Vehicle currentVehicle = this.GetComponentInParent<Vehicle>();
                Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();

                for (int i = 0; i < currentVehicle._vehicleHealth.Length; i++)
                {
                    currentVehicle._vehicleHealth[i].enabled = true;
                }

                currentVehicle.player = currentPlayer;
                currentPlayer.isInVehicle = true;
                boxCollider2D.enabled = false;
                var transform2 = other.transform;
                transform2.position = vehicle.transform.position;
                transform2.rotation = vehicle.transform.rotation;
                transform2.parent = vehicle.transform;
                playerBody.isKinematic = true;
                vehicle.name = "CurrentVehicle";
                // spriteRenderer.enabled = false;
            }
        }
    }
}