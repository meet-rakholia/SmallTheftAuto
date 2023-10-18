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
                GameObject vehicle = GameObject.Find("Vehicle");
                other.transform.rotation = quaternion.Euler(0.0f,0.0f,0.0f);
                vehicle.transform.parent = other.transform;
                SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
                BoxCollider2D boxCollider2D = other.GetComponent<BoxCollider2D>();
                boxCollider2D.enabled = false;
            }
        }
    }
}