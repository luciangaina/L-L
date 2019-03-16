using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y); //run

        if(Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce); //jump
        }
    }
}
