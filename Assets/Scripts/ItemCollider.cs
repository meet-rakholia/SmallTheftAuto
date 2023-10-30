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
                GameObject itemGameObject = other.gameObject.transform.Find("Item").gameObject;
                SpriteRenderer playerItemSprite = itemGameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer itemSprite = this.GetComponent<SpriteRenderer>();
                Player player = other.GetComponent<Player>();
                Item item = this.gameObject.GetComponent<Item>();
                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i] == null)
                    {
                        player._items[i] = item;
                        player._items[i].itemColor = itemSprite.color;
                        break;
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}