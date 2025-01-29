using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //create a public referance to the player
    public GameObject player; 

    void Update()
    {

    transform.position= new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);    
    }
}
