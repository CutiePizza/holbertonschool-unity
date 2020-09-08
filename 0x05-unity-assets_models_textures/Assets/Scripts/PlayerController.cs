using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
   /* private CharacterController _controller;
    // this way only our script can access it
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _doubleJumpMultiplier = 0.5f;
    private float _gravity = 9.81f;
    private float _jumpSpeed = 10f;
    private float _directionY;
    private bool _canDoubleJump = false;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Intializing a direction value
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        
        if (_controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            direction.y = _jumpSpeed;    
        }

        direction.y -= _gravity * Time.deltaTime;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);   
    }
    */
    
    
    
    
    
    
  /*  public float speed = 6f;
    public CharacterController controller;
    public Transform cam;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpHeight = 7f;
    public float maxJumps = 2f;
    public bool isGrounded;
    public float numberJumps = 0f;
    //private float _gravity = 9.81f;


    // Update is called once per frame
    void FixedUpdate()
    {
        // between -1 and 1
       // -1 if A key pressed or left arrow
       // 1 if D key or right arrow
       float horizontal = Input.GetAxisRaw("Horizontal");
       // -1 S or down key
       //1 if W or Up key
       float vertical = Input.GetAxisRaw("Vertical");
       Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
       if (direction.magnitude >= 0.1f)
       {
          float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
          float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
          transform.rotation = Quaternion.Euler(0f, angle, 0f);
          Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
          controller.Move(moveDir.normalized * speed * Time.deltaTime);
       }
       if (numberJumps > maxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpHeight;
                numberJumps += 1;
            }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        isGrounded = true;
        numberJumps = 0;
        Debug.Log("HHAHAHA");
    }*/



    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        
        
    }

    void FixedUpdate()
    {
            //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

