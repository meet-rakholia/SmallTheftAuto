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
            if (other.gameObject.name == "Player")
            {
                Weapon weapon = this.gameObject.GetComponent<Weapon>();
                GameObject item =  other.gameObject.transform.GetChild(0).gameObject;
                for (int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    GameObject child = this.gameObject.transform.GetChild(i).gameObject;
                    if (child.GetComponent<BulletPoolManager>())
                    {
                        child.transform.parent = other.transform;
                        break;
                    }
                }
                
                
                
                SpriteRenderer itemSprite = this.GetComponent<SpriteRenderer>();
                Player player = other.GetComponent<Player>();
                for (int i = 0; i < player._items.Length; i++)
                {
                    if (player._items[i].itemType == Item.ItemType.Weapon)
                    {
                        player._items[i].itemData["ammo"] = weapon.ammo;
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
                            {"ammo", weapon.ammo},
                            {"magazine", weapon.magazine},
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