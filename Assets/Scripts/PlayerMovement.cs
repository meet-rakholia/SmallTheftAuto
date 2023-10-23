using DefaultNamespace;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float playerRunningSpeed = 2.0f;
    public float playerTurnRate = 120.0f;
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
        float verticalInput = Input.GetAxis("Vertical");

        if (!_player.isInVehicle)
        {
            Vector3 movement = new Vector3(0.0f,verticalInput, 0.0f) * playerRunningSpeed;
            this.transform.Translate(movement*Time.deltaTime);
            _animator.SetBool(IsMoving,movement.magnitude > 0);
        
            Vector3 currentOrientation = this.transform.eulerAngles;
            float newRotation = currentOrientation.z - horizontalInput*playerTurnRate * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0.0f,0.0f,newRotation);
        }
        
    }
    
}
