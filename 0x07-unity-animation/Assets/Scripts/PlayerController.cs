using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    private CharacterController controller;
    [SerializeField]
    private float speed = 6;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3;

    [SerializeField]
    public Transform player;
    [SerializeField]
    public Transform respawnPoint;
    //private bool isDead = false;
    Vector3 velocity;
    bool isGrounded;
    public Transform cam;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    private float numberJumps = 0;
    private float MaxJumps = 1;
    private bool isAnime = false;
    bool ifPaused;
    public Animator anim;

    Timer timer;
    Text timerTex;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player.transform.position = new Vector3(0, 1.25f, 0);
        PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);   
    }

    // Update is called once per frame
    void Update()
    {
        ifPaused = this.GetComponent<PauseMenu>().isPaused;
        if (ifPaused == false)
        {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

       /* if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }*/
        if (isGrounded)
            numberJumps = 0;

        if (isGrounded || numberJumps < MaxJumps)
        {
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            numberJumps++;
            if (isGrounded)
                anim.SetTrigger("isjumping");
        }
        }
        if (isGrounded)
        {
            if (Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("s") || Input.GetKey("down") || Input.GetKey("d") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("left"))
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);
        }  
        if (!isGrounded && velocity.y < -10)
        {
            anim.SetBool("isFalling", true);
            
        }
        else
        {
                anim.SetBool("isFalling", false);
        }
    }
    }
     IEnumerator LoadScene(float seconds)
    {
       yield return new WaitForSeconds(seconds);
       controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (ifPaused == false && isAnime == false)
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
        if (player.transform.position.y < -10)
        {
            player.transform.position = new Vector3(0, 30f, 0);
            //player.transform.rotation = new Quaternion(0.068f, -0.002f, -0.013f, 0);
            timer = player.GetComponent<Timer>();
            timer.timerText.text = "0:00.00";
            timer.enabled = false;
            
        }
        }
    }
}

