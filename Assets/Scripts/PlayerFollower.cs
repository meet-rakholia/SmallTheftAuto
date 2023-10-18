using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerFollower : MonoBehaviour
    {
        public GameObject player;
        private Vector3 offset;
        private void Start()
        {
            offset = this.transform.position - player.transform.position;
        }

        private void Update()
        {
            this.transform.SetPositionAndRotation(player.transform.position+offset,Quaternion.Euler(0,0,0));
        }
    }
}