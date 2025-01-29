using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update

    // much like the Start() and Update() methods, OnTriggerEnter2D is a special unity method that is called 
    //bu unity automatically at a specific point 
    // to this Game Object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the GameObject that has collided with out trigger is tagged with cleanup 
        if (collision.gameObject.tag == "CleanUp")
        {
            //then we use this method to destroy it 
            Destroy(collision.gameObject);
        }



    }
}
    