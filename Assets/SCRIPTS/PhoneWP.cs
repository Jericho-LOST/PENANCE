using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneWP : MonoBehaviour

{
    //make phone move up waypoint when clicked. 

    [SerializeField] GameObject[] waypoints;
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {
        if ( Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);

            // Debug.Log("Show");
        }
      //  if (Input.GetMouseButtonUp(0))
      //  {
           // Debug.Log("Hide");
        //}
    }
}



