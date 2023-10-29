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
                    Debug.Log(playerItemSprite.color);
                    Debug.Log(itemSprite.color);
                    if (player._items[i] == null)
                    {
                        player._items[i] = item;
                        playerItemSprite.color = itemSprite.color;
                        playerItemSprite.enabled = true;
                        break;
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}