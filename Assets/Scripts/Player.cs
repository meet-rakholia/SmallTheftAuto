using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public bool isReadingAQuest;
        public bool isInVehicle;
        private int health = 100;
        private int gold = 0;
        private int score = 0;
        private Canvas _healthCanvas;
        private Image[] _health = new Image[5];
        private readonly string _spritePathNoHealth = "Sprites/Player/NoHealth";
        private readonly string _spritePathHalfHealth = "Sprites/Player/HalfHealth";
        private readonly string _spritePathFullHealth = "Sprites/Player/FullHealth";
        private TextMeshProUGUI _textGold;
        private TextMeshProUGUI _textScore;
        public Quest _currentQuest;
        public int _numberOfCompletedQuests = 0;
        public Item[] _items = new Item[3];

        private void Start()
        {
            GameObject canvasObject = GameObject.Find("Canvas");
            _healthCanvas = canvasObject.GetComponent<Canvas>();
            Image[] allImages = _healthCanvas.GetComponentsInChildren<Image>();
            TextMeshProUGUI[] textMeshPros = _healthCanvas.GetComponentsInChildren<TextMeshProUGUI>();
            
            int j = 0;
            for (int i = 0; i < allImages.Length; i++)
            {
                if (allImages[i].name.Contains("PlayerHealth"))
                {
                    _health[j] = allImages[i];
                    j++;
                }
            }
            
            for (int i = 0; i < textMeshPros.Length; i++)
            {
                if (textMeshPros[i].name.Contains("PlayerGold"))
                {
                    _textGold = textMeshPros[i];

                }
               
                if (textMeshPros[i].name.Contains("PlayerScore"))
                {
                    _textScore = textMeshPros[i];
                }
            }
            
            UpdatePlayerHealthIcons();
            UpdateGoldUI();
            UpdateScoreUI();

        }

        public void Heal(int value)
        {
            health = Math.Max(100,health + value);
            UpdatePlayerHealthIcons();
        }
        
        public void Damage(int damageAmount)
        {
            health = Math.Max(0,health - damageAmount);
            Debug.Log(health);
            UpdatePlayerHealthIcons();
        }

        public void UpdateGold(bool isNegative, int value)
        {
            if (isNegative)
            {
                gold = Math.Max(0, gold - value);
            }
            else
            {
                gold = gold + value;
            }
            UpdateGoldUI();
        }
        
        public void UpdateScore(bool isNegative, int value)
        {
            if (isNegative)
            {
                score = Math.Max(0, score - value);
            }
            else
            {
                score = score + value;
            }
            UpdateScoreUI();
        }

        private void UpdateGoldUI()
        {
            _textGold.text = "$" + gold.ToString();
        }
        
        private void UpdateScoreUI()
        {
            _textScore.text = "Score: " + score.ToString();
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