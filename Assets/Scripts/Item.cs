using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour
    {
        public string name = "";
        public ItemType itemtype;
        public Color itemColor; 
        
        public enum ItemType
        {
            Weapon = 0,
            HealthUp = 1,
            PowerUp = 2,
            QuestItem = 3
        }
    }
}