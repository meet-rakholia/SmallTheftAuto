using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealPlayer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.Heal(20);
                Destroy(this.gameObject);
            }
        }
    }
}