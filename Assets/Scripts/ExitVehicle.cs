using System;
using Unity.VisualScripting;
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
        private Rigidbody2D _rigidbody;
        private void Start()
        {
            _player = this.GetComponent<Player>();
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _collider = this.GetComponent<BoxCollider2D>();
            _rigidbody = this.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _player.isInVehicle)
            {
                
                _vehicle = GameObject.Find("CurrentVehicle");
                Vehicle currentVehicle = _vehicle.GetComponent<Vehicle>();
                for (int i = 0; i < currentVehicle._vehicleHealth.Length; i++)
                {
                    currentVehicle._vehicleHealth[i].enabled = false;
                }
                _player.isInVehicle = false;
                this.transform.parent = null;
                UnityEngine.Vector3 relativePosition = _vehicle.transform.right * -1.5f;
                UnityEngine.Vector3 finalPosition = _vehicle.transform.position + relativePosition;
                _player.transform.position = finalPosition;
                _spriteRenderer.enabled = true;
                _collider.enabled = true;
                _rigidbody.isKinematic = false;
                _vehicle.name = "Vehicle";
            }
        }
    }
}