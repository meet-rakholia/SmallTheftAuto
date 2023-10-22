using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public bool isInVehicle;
        public int health = 100;
        private Canvas _healthCanvas;
        private Image[] _health;
        private readonly string _spritePath = "Sprites/Player";

        private void Start()
        {
            GameObject canvasObject = GameObject.Find("HealthCanvas");
            _healthCanvas = canvasObject.GetComponent<Canvas>();
            _health = _healthCanvas.GetComponentsInChildren<Image>();
            Debug.Log(_health.Length);
            UpdatePlayerHealthIcons();
        }

        public void Heal()
        {
            health = Math.Max(100,health + 30);
            UpdatePlayerHealthIcons();
        }
        
        public void Damage(int damageAmount)
        {
            health = Math.Min(0,health - damageAmount);
            UpdatePlayerHealthIcons();
        }

        private void UpdatePlayerHealthIcons()
        {
            if (health == 100)
            {
                
            }
        }
    }
}