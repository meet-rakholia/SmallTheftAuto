using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace DefaultNamespace
{
    public class ExitVehicle : MonoBehaviour
    {
        private Player _player;
        private GameObject _vehicle;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;
        private void Start()
        {
            _player = this.GetComponent<Player>();
            _vehicle = GameObject.Find("Vehicle");
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _collider = this.GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _player.isInVehicle)
            {
                _player.isInVehicle = false;
                _vehicle.transform.parent = null;
                UnityEngine.Vector3 relativePosition = _vehicle.transform.right * -1.5f;
                UnityEngine.Vector3 finalPosition = _vehicle.transform.position + relativePosition;
                _player.transform.position = finalPosition;
                _spriteRenderer.enabled = true;
                _collider.enabled = true;
            }
        }
    }
}