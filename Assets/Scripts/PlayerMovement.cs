using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int playerRunningSpeed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        Vector3 movement = new Vector3(horizontalInput,verticalInput, 0.0f) * playerRunningSpeed;
        this.transform.Translate(movement*Time.deltaTime);
    }
    
}
