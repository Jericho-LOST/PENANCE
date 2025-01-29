using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {  
    GameObject player;     //reference to the player so we can track it's position 
    Renderer rend;     //Reference to the renderer so we can modify the texture 

    float playerStarterPos; //Float used to track the starting position of the player 
    public float speed = 0.5f;   //how fast should we scroll? we change this for each layer 

    void Start()
    {
        player = GameObject.Find("Cubii");     //find the player 
       rend = GetComponent<Renderer>(); //find the renderer 
   playerStarterPos = player.transform.position.x; // save our starting position 
    } 
    void Update()
    {
        float offset = (player.transform.position.x - playerStarterPos) * speed;
        //this line finds out much to offset the texture by 
        // We do this by subtracting out starting X position 
        //We then multiply the offset by the speed, so that we can have differewnt layers moving at different speeds
      
        rend.material.SetTextureOffset("_MainTex",new Vector2(offset,0f));
    }
}
