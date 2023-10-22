using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public bool isInVehicle;
        public int health = 50;
        private Canvas _healthCanvas;
        private Image[] _health = new Image[5];
        private readonly string _spritePathNoHealth = "Sprites/Player/NoHealth";
        private readonly string _spritePathHalfHealth = "Sprites/Player/HalfHealth";
        private readonly string _spritePathFullHealth = "Sprites/Player/FullHealth";

        private void Start()
        {
            GameObject canvasObject = GameObject.Find("Canvas");
            _healthCanvas = canvasObject.GetComponent<Canvas>();
            Image[] allImages = _healthCanvas.GetComponentsInChildren<Image>();
            int j = 0;
            for (int i = 0; i < allImages.Length; i++)
            {
                if (allImages[i].name.Contains("PlayerHealth"))
                {
                    _health[j] = allImages[i];
                    Debug.Log(_health[j].name);
                    j++;
                }
            }
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
                foreach (var t in _health)
                {
                    t.sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                }
            }
            else if (health is >= 90 and < 100)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 80 and < 90)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 70 and < 80)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 60 and < 70)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 50 and < 60)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 40 and < 50)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 30 and < 40)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 20 and < 30)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
            }
            else if (health is >= 10 and < 20)
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
            }
            else
            {
                _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _health[4].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
            }

        }
    }
}