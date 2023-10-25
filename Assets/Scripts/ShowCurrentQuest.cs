using System;
using System.Collections;
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
            GameObject canvasGameObject = GameObject.Find("Canvas");
            _notificationPanel = canvasGameObject.transform.Find("NotificationPanel").gameObject;
            _notificationtext = _notificationPanel.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void onQuestClick()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            if (_player._currentQuest)
            {
                StartCoroutine(showQuestCoroutine(_player._currentQuest.questText));
            }
        }

        private IEnumerator showQuestCoroutine(string message)
        {
            _notificationtext.text = message;
            _notificationPanel.SetActive(true);
            

            yield return new WaitForSeconds(5);

            _notificationtext.text = "";
            _notificationPanel.SetActive(false);
        }
    }
}