using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Quest1 : MonoBehaviour
    {
        private Vehicle _vehicle;
        private PolygonCollider2D _quest1;
        private void Start()
        {
            GameObject vehicleGameObject = this.gameObject;
            _vehicle = vehicleGameObject.GetComponent<Vehicle>();
            _quest1 = GameObject.Find("Quest1").GetComponent<PolygonCollider2D>();

        }

        private void Update()
        {
            if (_vehicle.player)
            {
                if (_vehicle.player._currentQuest)
                {
                    if (_vehicle.player._currentQuest.questName == "Quest1")
                    {
                        Quest1Done();
                    }
                }
            }
        }

        private void Quest1Done()
        {
            GameObject canvasGameObject = GameObject.Find("Canvas");
            GameObject currentQuestPanel = canvasGameObject.transform.Find("CurrentQuest").gameObject;
            GameObject questButton = currentQuestPanel.transform.Find("Button").gameObject;
            TextMeshProUGUI currentQuestText = questButton.GetComponentInChildren<TextMeshProUGUI>();
            GameObject notificationPanel = canvasGameObject.transform.Find("NotificationPanel").gameObject;
            TextMeshProUGUI notificationtext = notificationPanel.GetComponentInChildren<TextMeshProUGUI>();
            
            StartCoroutine(ShowQuest1Done(notificationtext,notificationPanel,_vehicle.player._currentQuest.questName));
            
            _vehicle.player._currentQuest = null;
            currentQuestText.text = "No Quest";
            _vehicle.player.UpdateGold(false,500);
            _vehicle.player._numberOfCompletedQuests += 1;
            
        }

        private IEnumerator ShowQuest1Done(TextMeshProUGUI _notificationtext, GameObject _notificationPanel, string questName)
        {
            _notificationtext.text = questName + ": Completed!!!";
            _notificationPanel.SetActive(true);


            yield return new WaitForSeconds(2);

            _notificationtext.text = "";
            _notificationPanel.SetActive(false);
            Destroy(_quest1);
        }
    }
}