using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Vehicle vehicle = other.gameObject.GetComponent<Vehicle>();
            Building building = other.gameObject.GetComponent<Building>();
            Wall wall = other.gameObject.GetComponent<Wall>();
            if (vehicle)
            {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                Bullet bullet = this.gameObject.GetComponent<Bullet>();
                vehicle.Damage(player._currentItem.itemData["damage"]);
                this.gameObject.SetActive(false);
            } else if (building || wall)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}