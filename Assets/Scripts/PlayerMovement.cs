using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int playerRunningSpeed = 1;
    private Animator _animator;
    private static readonly int MoveX = Animator.StringToHash("MoveX");

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        
        Vector3 movement = new Vector3(horizontalInput,verticalInput, 0.0f) * playerRunningSpeed;
        this.transform.Translate(movement*Time.deltaTime);
        _animator.SetFloat("MoveX",horizontalInput);
        _animator.SetFloat("MoveY",verticalInput);
        _animator.SetBool("isMoving",movement.magnitude > 0);
    }
    
}
