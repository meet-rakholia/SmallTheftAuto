using UnityEngine;


namespace DefaultNamespace
{
    public class ExitVehicle : MonoBehaviour
    {
        private Player _player;
        private GameObject _vehicle;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;
        private Rigidbody2D _rigidbody;
        private Vehicle _currentVehicle;
        private void Start()
        {
            _player = this.GetComponent<Player>();
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _collider = this.GetComponent<BoxCollider2D>();
            _rigidbody = this.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_player.isInVehicle)
            {
                if (!_vehicle)
                {
                    _vehicle = GameObject.Find("CurrentVehicle");
                    _currentVehicle = _vehicle.GetComponent<Vehicle>(); 
                }
                
                if(Input.GetKeyDown(KeyCode.E) || _currentVehicle.vehicleHealth == 0)
                {
                
                    SpriteRenderer vehicleSprite = _vehicle.GetComponent<SpriteRenderer>();
                    for (int i = 0; i < _currentVehicle._vehicleHealth.Length; i++)
                    {
                        _currentVehicle._vehicleHealth[i].enabled = false;
                    }
                    _player.isInVehicle = false;
                    this.transform.parent = null;
                    Vector3 relativePosition = _vehicle.transform.right * -1.5f;
                    Vector3 finalPosition = _vehicle.transform.position + relativePosition;
                    _player.transform.position = finalPosition;
                    _spriteRenderer.enabled = true;
                    _collider.enabled = true;
                    _rigidbody.isKinematic = false;
                    _vehicle.name = "Vehicle";
                    vehicleSprite.color = _currentVehicle.vehicleHealth == 0 ? Color.gray : Color.white;
                    _vehicle = null;
                }
            }
                
        }
    }
}