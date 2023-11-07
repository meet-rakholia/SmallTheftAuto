using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerFollower : MonoBehaviour
    {
        public GameObject player;
        private Vector3 _offset;
        private Player _player;
        private void Start()
        {
            _offset = this.transform.position - player.transform.position;
        }
        

        private void LateUpdate()
        {
            Vector3 desiredPosition = player.transform.position + _offset;
            this.transform.position = Vector3.Lerp(transform.position, desiredPosition, 1.5f*Time.deltaTime);        }
    }
}