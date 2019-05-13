using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public bool crouched = false;
    private float crouchTimer = 0f;
    public float maxCrouchTime = 0.5f;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); //run

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                jumpSound.Play();
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce); //jump
                stoppedJumping = false;
            }
        }

        if(Input.GetKey(KeyCode.W) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        if(Input.GetKeyDown(KeyCode.S) && !crouched)
        {
            crouchTimer = 0f;
            myAnimator.SetBool("Crouching", true);
            crouched = true;
        }

        if(crouched)
        {
            crouchTimer += Time.deltaTime;

            if(crouchTimer > maxCrouchTime)
            {
                crouched = false;
                myAnimator.SetBool("Crouching", false);
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="killbox")
        {
            deathSound.Play();
            theGameManager.EndGame();
        }
    }
}
