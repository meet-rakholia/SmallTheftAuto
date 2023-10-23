using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class VehicleMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        public float vehicleRunningSpeed = 3.0f;
        public float vehicleTurnRate = 200.0f;
        private Vehicle _vehicle;
        void Start()
        {
            _vehicle = this.GetComponent<Vehicle>();
        }

        // Update is called once per frame
        void Update()
        {
        
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            

            if (_vehicle.player && _vehicle.name == "CurrentVehicle")
            {
                if (_vehicle.player.isInVehicle)
                {
                    if (Math.Abs(verticalInput) > 0.1f)
                    {
                        Vector3 currentOrientation = this.transform.eulerAngles;
                        float newRotation = currentOrientation.z - horizontalInput*vehicleTurnRate * Time.deltaTime;
                        this.transform.rotation = Quaternion.Euler(0.0f,0.0f,newRotation);
                    }
                    
                    Vector3 movement = new Vector3(0.0f,verticalInput, 0.0f) * vehicleRunningSpeed;
                    this.transform.Translate(movement*Time.deltaTime);
                }
            }
        }
    }
}