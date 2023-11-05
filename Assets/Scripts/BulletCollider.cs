using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name.Contains("Vehicle"))
            {
                Vehicle vehicle = other.gameObject.GetComponent<Vehicle>();
                vehicle.Damage(5);
                this.gameObject.SetActive(false);
            } else if (other.gameObject.name.Contains("Building") || other.gameObject.name.Contains("Wall"))
            {
                this.gameObject.transform.position = new Vector3();
                this.gameObject.transform.rotation = new Quaternion();
                this.gameObject.SetActive(false);
            }
        }
    }
}