using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemCollider : MonoBehaviour
    {
       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Player player = other.GetComponent<Player>();
                Item item = this.gameObject.GetComponent<Item>();
                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i] == null)
                    {
                        player._items[i] = item;
                        break;
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}