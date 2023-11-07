using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UseItem : MonoBehaviour
    {
        public Player _player;
        public BulletPoolManager _bulletPoolManager;
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI itemCharge;
        public Image itemImage;

        private void Start()
        {
            Transform parent = this.gameObject.transform.parent;
            _player = parent.gameObject.GetComponent<Player>();

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
                }
            }
        }

        private void Fire()
        {
            if (!_bulletPoolManager)
            {
                _bulletPoolManager = this.gameObject.transform.parent.GetComponentInChildren<BulletPoolManager>();
            }
            GameObject bullet = _bulletPoolManager.getBullet();
            SpriteRenderer bulletSprite = bullet.GetComponent<SpriteRenderer>();
            bullet.SetActive(true); 
            bulletSprite.enabled = true;
            var parent = this.gameObject.transform.parent;
            var position = parent.position;
            float angle = parent.rotation.eulerAngles.z;
            bullet.transform.position = this.gameObject.transform.position;
            bullet.transform.rotation = parent.rotation;
            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody2D.AddForce(
                new Vector2(-_player._currentItem.itemData["force"] * (float)Math.Sin(angle * Math.PI / 180),
                    (float)_player._currentItem.itemData["force"] * (float)Math.Cos(angle * Math.PI / 180)),
                ForceMode2D.Impulse);
        }
        
        private void UpdateItemUI()
        {
            SpriteRenderer itemSprite = this.gameObject.GetComponent<SpriteRenderer>();

            if (_player._currentItem.itemType == Item.ItemType.NoItem)
            {
                itemSprite.enabled = false;
                itemImage.sprite = null;
                itemName.text = "No Item";
                itemCharge.text = "Charge: 0";
            }
            else
            {
                itemSprite.enabled = true;
                itemSprite.sprite = _player._currentItem.itemSprite;
                itemImage.sprite = _player._currentItem.itemSprite;;
                itemName.text = _player._currentItem.name;;
                if (_player._currentItem.itemType == Item.ItemType.Weapon)
                {
                    itemCharge.text =
                        $"Charge: {_player._currentItem.itemData["currentBullets"]}/{_player._currentItem.itemData["maxBullets"]}";
                }
                else
                {
                    itemCharge.text = 
                        $"Charge: {_player._currentItem.charge}";
                }
            }
        }
    }
}