using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item
    {
        public string name = "";
        public Color itemColor = Color.clear;
        public int charge = 0;
        public ItemType itemType = ItemType.NoItem;
        public Dictionary<string, int> itemData = new Dictionary<string, int>() {};
        
        public enum ItemType
        {
            NoItem = 0,
            Weapon = 1,
            Healthup = 2,
            Powerup = 3,
            Quest = 4
        }
    }
    
}