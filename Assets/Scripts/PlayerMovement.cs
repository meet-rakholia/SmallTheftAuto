using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float playerRunningSpeed = 1.0f;
    public float playerTurnRate = 30.0f;
    public float vehicleAcceleration = 1.0f;
    public float maxVehicleSpeed = 5.0f;
    public float vehicleTurnRate = 200.0f;
    private Animator _animator; 
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private Player _player;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _player = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float turnRate;

        if (_player.isInVehicle)
        {
            turnRate = vehicleTurnRate;
            if (Input.GetKeyDown(KeyCode.W))
            {
                
            }
            
        }
        else
        {
            float verticalInput = Input.GetAxis("Vertical");
            turnRate = playerTurnRate;
    
            Vector3 movement = new Vector3(0.0f,verticalInput, 0.0f) * playerRunningSpeed;
            this.transform.Translate(movement*Time.deltaTime);
            _animator.SetBool(IsMoving,movement.magnitude > 0);
        }
        
        Vector3 currentOrientation = this.transform.eulerAngles;
        float newRotation = currentOrientation.z - horizontalInput*turnRate * Time.deltaTime;
        this.transform.rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f,newRotation);

    }
    
}
