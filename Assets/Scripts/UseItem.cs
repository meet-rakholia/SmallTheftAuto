using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class UseItem : MonoBehaviour
    {
        public Player _player;

        private void Start()
        {
            _player = this.gameObject.transform.parent.gameObject.GetComponent<Player>();
        }

        private void Update()
        {
            if (_player._currentItem.itemType == Item.ItemType.NoItem)
            {
                for (int i = 0; i < _player._items.Length; i++)
                {
                    if (_player._items[i].itemType != Item.ItemType.NoItem)
                    {
                        _player._currentItem = _player._items[i];
                        _player._itemIndex = i;
                        UpdateItemUI();
                        break;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && !_player.isInVehicle)
            {
                _player._itemIndex = _player._itemIndex < _player._items.Length-1 ? _player._itemIndex + 1 : 0;
                _player._currentItem = _player._items[_player._itemIndex];
                UpdateItemUI();
            }

            if (Input.GetKeyDown(KeyCode.Space) && !_player.isInVehicle)
            {
                if (_player._currentItem.itemType == Item.ItemType.Healthup)
                {
                    _player.Heal(_player._currentItem.itemData["heal"]);
                    _player._currentItem.charge -= 1;
                    if (_player._currentItem.charge == 0)
                    {
                        _player._currentItem = new Item();
                        _player._items[_player._itemIndex] = new Item();
                        UpdateItemUI();
                    }
                } else if (_player._currentItem.itemType == Item.ItemType.Weapon)
                {
                    Fire();
                    UpdateItemUI();
                }
            }
        }

        private void Fire()
        {
            
        }
        
        private void UpdateItemUI()
        {
            SpriteRenderer itemSprite = this.gameObject.GetComponent<SpriteRenderer>();

            if (_player._currentItem.itemType == Item.ItemType.NoItem)
            {
                itemSprite.enabled = false;
            }
            else
            {
                itemSprite.enabled = true;
                itemSprite.sprite = _player._currentItem.itemSprite;
            }
        }
    }
}