using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShowCurrentQuest : MonoBehaviour
    {
        private Player _player;
        private GameObject _notificationPanel;
        private TextMeshProUGUI _notificationtext;
        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _notificationPanel = canvasGameObject.transform.Find("NotificationPanel").gameObject;
            _notificationtext = _notificationPanel.GetComponentInChildren<TextMeshProUGUI>();
        }

        public onQuestClick()
        {
            if (_player._currentQuest)
            {
                _notificationtext = 
                    _notificationPanel.SetActive(true);
            }
            
        }
    }
}