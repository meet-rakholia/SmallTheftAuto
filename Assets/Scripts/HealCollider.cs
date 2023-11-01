using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealCollider : MonoBehaviour
    {
       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                SpriteRenderer itemSprite = this.GetComponent<SpriteRenderer>();
                Player player = other.GetComponent<Player>();
                HealthUp healthUp = this.gameObject.GetComponent<HealthUp>();
                
                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i].itemType == Item.ItemType.Healthup)
                    {
                        player._items[i].charge += 1;
                        Destroy(this.gameObject);
                        return;
                    }
                }

                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i].itemType == Item.ItemType.NoItem)
                    {
                        player._items[i].charge = 1;
                        player._items[i].itemColor = itemSprite.color;
                        player._items[i].name = healthUp.name;
                        player._items[i].itemData = new Dictionary<string, int>()
                        {
                            { "heal", healthUp.heal }
                        };
                        player._items[i].itemType = Item.ItemType.Healthup;
                        Destroy(this.gameObject);
                        return;
                    }
                }
                
            }
        }
    }
}