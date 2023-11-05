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
                Bullet bullet = this.gameObject.GetComponent<Bullet>();
                vehicle.Damage(bullet.damage);
                this.gameObject.SetActive(false);
            } else if (other.gameObject.name.Contains("Building") || other.gameObject.name.Contains("Wall"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}