using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementF : MonoBehaviour
{
    //SIDE MOVEMENT
    Rigidbody2D rgb;

    private float horizontal; // this is just movement- did'nt need to be called horizontal
   
    public float Speed = 20.0f;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Give a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
      //  vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
      

        rgb.velocity = new Vector2 (horizontal * Speed,rgb.velocity.y); // ,vertical * Speed);
    }

}
