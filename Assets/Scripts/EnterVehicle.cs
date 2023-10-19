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
                GameObject vehicle = GameObject.Find("Vehicle");
                BoxCollider2D boxCollider2D = other.GetComponent<BoxCollider2D>();
                SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
                Vehicle currentVehicle = this.GetComponentInParent<Vehicle>();

                currentVehicle.player = currentPlayer;
                currentPlayer.isInVehicle = true;
                boxCollider2D.enabled = false;
                var transform2 = other.transform;
                transform2.position = vehicle.transform.position;
                transform2.rotation = vehicle.transform.rotation;
                transform2.parent = vehicle.transform;
                // spriteRenderer.enabled = false;
            }
        }
    }
}