using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce; // i don't think ill need the jump feature but ill keep it anyhow

    public Transform groundCheckPoint;
    public LayerMask groundlayer;
    private bool isGrounded;
    public float checkRadius = 0.2f;

    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
 
        void Update()

        {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundlayer);

        //Moves Forward and back along y axis                           //Up/Down
        transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical") * speed);


        //Moves Left and right along x Axis                               //Left/Right
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);



        if (Input.GetButtonDown("Jump") && Mathf.Abs(rgb.velocity.y) < 0.001f)

            {

            rgb.AddForce(new Vector2(0, jumpForce)); //ForceMode2D.Impulse);

            }

        }
    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualise the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }

}
