using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;               //constant forward speed
    public float jumpForce = 10f;              //Jump Force
    public Transform groundCheckPoint;         // a point to check if the player is grounded 
    public float checkRadius = 0.2f;           //Radius of the overlap circle for ground detection
    public LayerMask groundlayer;              //layer of ground objects 

    private Rigidbody2D rb;                    //Referance to the rigidbody componant 
    private bool isGrounded;                   // is the player on the ground?



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // get the rigidbody2d componant attatched to the player 
    }

    void Update()
    {
        //constant forward movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); 

        //check if the player is grounded 
        isGrounded =Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundlayer);

        //jumping Logic

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump ();
        }
    }
    private void Jump ()
    {
        //Add an upward force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualise the ground check point in the editor
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}

