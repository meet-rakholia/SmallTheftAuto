using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShowInstructions : MonoBehaviour
    {
        private GameObject _instructionPanel,_buttons;
        private bool _isOpen;

        private void Start()
        {
            GameObject canvas = GameObject.Find("Canvas");
            _instructionPanel = canvas.transform.Find("InstructionPanel").gameObject;
            _buttons = canvas.transform.Find("Buttons").gameObject;
        }


        public void showInsructions()
        {
            _instructionPanel.SetActive(true);
            _buttons.SetActive(false);
            _isOpen = true;
        }
        
        public void hideInsructions()
        {
            _instructionPanel.SetActive(false);
            _buttons.SetActive(true);
            _isOpen = false;
        }
    }
}