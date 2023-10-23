using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Vehicle : MonoBehaviour
    {
        public Player player;
        public int vehicleHealth = 100;
        private Canvas _vehicleHealthCanvas;
        public UnityEngine.UI.Image[] _vehicleHealth = new UnityEngine.UI.Image[5]; 
        private readonly string _spritePathNoHealth = "Sprites/Player/NoHealth";
        private readonly string _spritePathHalfHealthVehicle = "Sprites/Player/HalfHealthVehicle";
        private readonly string _spritePathFullHealthVehicle = "Sprites/Player/FullHealthVehicle";

        private void Start()
        {
            GameObject canvasObject = GameObject.Find("Canvas");
            _vehicleHealthCanvas = canvasObject.GetComponent<Canvas>();
            UnityEngine.UI.Image[] allImages = _vehicleHealthCanvas.GetComponentsInChildren<UnityEngine.UI.Image>();


            int j = 0;
            for (int i = 0; i < allImages.Length; i++)
            {
                if (allImages[i].name.Contains("VehicleHealth"))
                {
                    _vehicleHealth[j] = allImages[i];
                    _vehicleHealth[j].enabled = false;
                    j++;
                }
            }

            UpdateVehicleHealthIcons();
        }

        public void Damage(int damageAmount)
        {
            vehicleHealth = Math.Max(0, vehicleHealth - damageAmount);
            UpdateVehicleHealthIcons();
        }

        public void UpdateVehicleHealthIcons()
        {
            if (vehicleHealth == 100)
            {
                foreach (var t in _vehicleHealth)
                {
                    t.sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                }
            }
            else if (vehicleHealth is >= 90 and < 100)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathHalfHealthVehicle);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 80 and < 90)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 70 and < 80)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathHalfHealthVehicle);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 60 and < 70)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 50 and < 60)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathHalfHealthVehicle);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 40 and < 50)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 30 and < 40)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathHalfHealthVehicle);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 20 and < 30)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathFullHealthVehicle);
            }
            else if (vehicleHealth is >= 10 and < 20)
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathHalfHealthVehicle);
            }
            else
            {
                _vehicleHealth[0].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[1].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[2].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[3].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
                _vehicleHealth[4].sprite = Resources.Load<Sprite>(_spritePathNoHealth);
            }
        }
    }
}