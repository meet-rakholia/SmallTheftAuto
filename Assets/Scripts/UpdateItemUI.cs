using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class UpdateItemUI : MonoBehaviour
    {
        private Player _player;
        private void Start()
        {
            _player = this.gameObject.transform.parent.gameObject.GetComponent<Player>();
        }
    }
}