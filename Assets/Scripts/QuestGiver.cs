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
        private GameObject _questPanel, _notificationPanel;
        private Quest _quest;
        private Player _player;
        private TextMeshProUGUI _questText;
        private void Start()
        {
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _questPanel = canvasGameObject.transform.Find("QuestPanel").gameObject;
            _notificationPanel = canvasGameObject.transform.Find("NotificationPanel").gameObject;
            _quest = _questPanel.GetComponent<Quest>();
            GameObject questTextGameObject = _questPanel.transform.Find("QuestText").gameObject;
            _questText = questTextGameObject.GetComponent<TextMeshProUGUI>();
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
            if (other.gameObject.name == "Player")
            {
                _player = other.gameObject.GetComponent<Player>();
                
                if (!_player.isReadingAQuest && !_player._currentQuest)
                {
                    _questText.text += _quest.questText ;
                    _questPanel.SetActive(true);
                    _player.isReadingAQuest = true;
                }

                if (_player._currentQuest)
                {
                    TextMeshProUGUI notificationText = _notificationPanel.GetComponentInChildren<TextMeshProUGUI>();
                    _notificationPanel.SetActive(true);
                    notificationText.text = "Player already has a quest";
                    
                }
                
            } 
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_player){
                if (_player._currentQuest)
                {
                    _notificationPanel.SetActive(false);
                }
            }
        }
    }
}