using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float playerRunningSpeed = 1.0f;
    public float playerTurnRate = 30.0f;
    private Animator _animator; 
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 currentOrientation = this.transform.eulerAngles;
        float newRotation = currentOrientation.z - horizontalInput*playerTurnRate * Time.deltaTime;
        this.transform.rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f,newRotation);
        
        Vector3 movement = new Vector3(0.0f,verticalInput, 0.0f) * playerRunningSpeed;
        this.transform.Translate(movement*Time.deltaTime);
        _animator.SetBool(IsMoving,movement.magnitude > 0);
    }
    
}
