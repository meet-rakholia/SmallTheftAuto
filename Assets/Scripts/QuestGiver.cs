using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuestGiver : MonoBehaviour
    {
        private GameObject _questPanel;
        private String _currentQuest;
        private Quest _quest;
        private void Start()
        {
            _currentQuest = this.gameObject.name;
            _quest = this.gameObject.GetComponent<Quest>();
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _questPanel = canvasGameObject.transform.Find("QuestPanel").gameObject;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.R))
            {
                Player player = other.gameObject.GetComponent<Player>();
                GameObject questTextGameObject = _questPanel.transform.Find("QuestText").gameObject;
                TextMeshProUGUI questText = questTextGameObject.GetComponent<TextMeshProUGUI>();
                
                if (!player.isReadingAQuest)
                {
                    questText.text += _quest.questText;
                    _questPanel.SetActive(true);
                    player.isReadingAQuest = true;
                }
                else
                {
                    questText.text = "";
                    _questPanel.SetActive(false);
                    player.isReadingAQuest = false;
                }
                
            } 
        }
    }
}