using System;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class QuestGiver : MonoBehaviour
    {
        private GameObject _questPanel;
        private String _currentQuest;
        private Quest _quest;
        private Player _player;
        private TextMeshProUGUI _questText;
        private void Start()
        {
            _currentQuest = this.gameObject.name;
            _quest = this.gameObject.GetComponent<Quest>();
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _questPanel = canvasGameObject.transform.Find("QuestPanel").gameObject;
        }

        private void Update()
        {
            if (_player)
            {
                if (_player.isReadingAQuest && Input.GetKeyDown(KeyCode.E))
                {
                    _questText.text = "Quest: ";
                    _questPanel.SetActive(false);
                    _player.isReadingAQuest = false;
                    _player = null;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("In");
            if (other.gameObject.name == "Player")
            {
                _player = other.gameObject.GetComponent<Player>();
                GameObject questTextGameObject = _questPanel.transform.Find("QuestText").gameObject;
                _questText = questTextGameObject.GetComponent<TextMeshProUGUI>();
                
                if (!_player.isReadingAQuest)
                {
                    _questText.text += _quest.questText;
                    _questPanel.SetActive(true);
                    _player.isReadingAQuest = true;
                }
                
            } 
            
            
        }
    }
}