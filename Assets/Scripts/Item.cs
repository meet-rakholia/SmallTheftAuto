using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour
    {
        public string name;

        public enum ItemType
        {
            Weapon = 0,
            HealthUp = 1,
            PowerUp = 2,
            QuestItem = 3
        };

        public class Weapon
        {
            public int damage;
            public int charge;
        }

        public class HealthUp
        {
            public int heal;
        }
        
        public class PowerUp
        {
            public int increasedMoveSpeed;
            public int increasedDamage;
            public int damageBarrier;
        }
        
    }
}