using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    
    public class QuestAccepter : MonoBehaviour
    {
        private Player _player;
        private Quest _quest;
        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            _quest = this.transform.parent.gameObject.GetComponent<Quest>();
        }

        public void AcceptQuest()
        {
            _player._currentQuest = _quest;
        }
        
        
    }
}