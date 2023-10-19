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
                currentPlayer.isInVehicle = true;
                BoxCollider2D boxCollider2D = other.GetComponent<BoxCollider2D>();
                boxCollider2D.enabled = false;
                GameObject vehicle = GameObject.Find("Vehicle");
                var transform1 = other.transform;
                transform1.position = vehicle.transform.position;
                transform1.rotation = vehicle.transform.rotation;
                vehicle.transform.parent = transform1;
                SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
            }
        }
    }
}