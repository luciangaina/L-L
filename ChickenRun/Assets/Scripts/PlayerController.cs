using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    public bool crouched = false;
    private float crouchTimer = 0f;
    public float maxCrouchTime = 0.5f;

    private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); //run

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce); //jump
            }
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
}
