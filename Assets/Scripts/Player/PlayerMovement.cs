using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Reference Youtube Source: BMo
// 2D Side Scroller MOVEMENT in Unity (BEGINNER FRIENDLY)
// https://www.youtube.com/watch?v=9HAZQROH2gM
// https://www.youtube.com/playlist?list=PLhrayuv80FeWPrco0bqfYSHDifVB2PXpW

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 20.0f;

    private Rigidbody2D rb;
    public Animator animator;
    private string currentAnimation = "";

    private bool facingRight = true;
    private float moveDirection;

    public float jumpForce = 15.0f;
    private bool isJumping = false;
    // private int jumpCount;
    // public int maxJumpCount = 3;

    public Transform ceilingCheck;
    public Transform groundCheck;

    public LayerMask groundObject;
    public bool isGrounded;
    public float checkRadius;

    public GameObject projectilePrefab;
    public Transform launchPoint;


    public void Start()
    {
        // jumpCount = maxJumpCount;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = true;


    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

    }

    private void ChangeAnimation(string animation, float crossfaderate = 0f)
    {
        if (currentAnimation != animation)
        {

            
            currentAnimation = animation;
            animator.Play(animation);
            // animator.CrossFade(animation, crossfaderate);
        }

    }

    private void FixedUpdate()
    {
        // Get Inputs
        ProcessInput();

        // Animate If FlipCharacter 180 for RightLeft
        Animate();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);
        // if (isGrounded)        {            jumpCount = maxJumpCount;         }

        // Move
        Move();

    }

    // Move to new direction
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            // rb.AddForce(new Vector2(0f, jumpForce));
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // jumpCount--;
        }
        isJumping = false;
    }

    // Flip/Rotate 180 Character Left/Right Right/Left
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipCharacter();
            animator.Play("Run"); // animator.CrossFade("Run", 0);

        }
        else if (moveDirection < 0 && facingRight)
        {
            flipCharacter();
            animator.Play("Run"); // animator.CrossFade("Run", 0);

        }
        else if (moveDirection == 0)
        {
            animator.Play("Idle"); // animator.CrossFade("Idle", 0);
        }
        //else if (Input.GetKeyDown(KeyCode.R) && moveDirection != 0) //  DASH        {            animator.CrossFade("Dash", 0);        }


        //else if (moveDirection == 0 && Input.GetKeyDown(KeyCode.DownArrow))   animator.CrossFade("MMX_Crouch", 0);



    }

    private void ProcessInput()
    {
        // Get Imputs
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") )// && jumpCount > 0) // if (Input.GetButtonDown("Jump")  && isGrounded) // if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            animator.Play("Jump"); // animator.CrossFade("Jump", 0f);
            isJumping = true;
            Debug.Log("Spacebar JUMP");
            // Debug.Log("JumpCount#: " + jumpCount);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) ) // && isGrounded) // && jumpCount > 0) // if (Input.GetButtonDown("Jump")  && isGrounded) // if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            animator.Play("IdleShoot"); // animator.CrossFade("Jump", 0f);
            Shoot();
            Debug.Log("LeftShift IdleShoot");
            

        }

    }

    private void flipCharacter()
    {
        facingRight = !facingRight;
        rb.transform.Rotate(0f, 180f, 0f);
        
    }

    private void Shoot()
    {

        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);  // transform.rotation);

    }

}
