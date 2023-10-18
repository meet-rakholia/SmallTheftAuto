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

        private void LateUpdate()
        {
            Vector3 desiredPosition = player.transform.position + offset;
            this.transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.99f * Time.deltaTime);        }
    }
}