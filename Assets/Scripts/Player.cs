using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public bool isInVehicle;
        public int health = 50;
        private Canvas _healthCanvas;
        private Image[] _health;
        private readonly string _spritePathNoHealth = "Sprites/Player/NoHealth";
        private readonly string _spritePathHalfHealth = "Sprites/Player/HalfHealth";
        private readonly string _spritePathFullHealth = "Sprites/Player/FullHealth";

        private void Start()
        {
            GameObject canvasObject = GameObject.Find("PlayerHealthCanvas");
            _healthCanvas = canvasObject.GetComponent<Canvas>();
            _health = _healthCanvas.GetComponentsInChildren<Image>();
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
            switch (health)
            {
                case 100:
                    foreach (var t in _health)
                    {
                        t.sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    }
                    break;
                case 90:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 80:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 70:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 60:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 50:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 40:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 30:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 20:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathFullHealth);
                    break;
                case 10:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathHalfHealth);
                    break;
                default:
                    _health[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    _health[4].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                    break;
            }
        }
    }
}