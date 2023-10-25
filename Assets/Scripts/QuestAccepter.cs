using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    public class QuestAccepter : MonoBehaviour
    {
        private Player _player;
        private Quest _quest;
        private GameObject _currentQuestPanel, _questPanel;
        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            _quest = this.transform.parent.gameObject.GetComponent<Quest>();
            _currentQuestPanel = GameObject.Find("Canvas").transform.Find("CurrentQuest").gameObject;
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _questPanel = canvasGameObject.transform.Find("QuestPanel").gameObject;
            
        }

        public void AcceptQuest()
        {
            GameObject questButton = _currentQuestPanel.transform.Find("Button").gameObject;
            TextMeshProUGUI currentQuestText = questButton.GetComponentInChildren<TextMeshProUGUI>();
            
            _player._currentQuest = _quest;
            currentQuestText.text = _quest.questName;
            _player.isReadingAQuest = false;
            _questPanel.SetActive(false);
        }
        
        
    }
}