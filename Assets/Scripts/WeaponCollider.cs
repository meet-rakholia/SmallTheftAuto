using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            BulletPoolManager bpm;
            if (other.gameObject.name == "Player")
            {
                Weapon weapon = this.gameObject.GetComponent<Weapon>();

                if (!other.gameObject.GetComponent<BulletPoolManager>())
                {
                    for (int i = 0; i < this.gameObject.transform.childCount; i++)
                    {
                        GameObject child = this.gameObject.transform.GetChild(i).gameObject;
                        if (child.GetComponent<BulletPoolManager>())
                        {
                        
                            child.transform.parent = other.transform;
                        
                            break;
                        }
                    }
                }
                
                SpriteRenderer itemSprite = this.GetComponent<SpriteRenderer>();
                Player player = other.GetComponent<Player>();
                UseItem useItem = other.gameObject.GetComponentInChildren<UseItem>();
                
                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i].itemType == Item.ItemType.Weapon)
                    {
                        if(player._items[i].itemData["currentBullets"] == weapon.maxBullets) return;
                        player._items[i].itemData["currentBullets"] = Math.Min(
                            player._items[i].itemData["currentBullets"] + weapon.currentBullets, weapon.maxBullets);
                        useItem.UpdateItemUI();
                        Destroy(this.gameObject);
                        return;
                    }
                }

                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i].itemType == Item.ItemType.NoItem)
                    {
                        player._items[i].charge = 1;
                        player._items[i].itemSprite = itemSprite.sprite;
                        player._items[i].name = weapon.name;
                        player._items[i].itemData = new Dictionary<string, int>()
                        {
                            {"damage", weapon.damage },
                            {"maxBullets", weapon.maxBullets},
                            {"currentBullets", weapon.currentBullets},
                            {"force", weapon.force},
                        };
                        player._items[i].itemType = Item.ItemType.Weapon;
                        Destroy(this.gameObject);
                        return;
                    }
                }
                
            }
        }
    }
}