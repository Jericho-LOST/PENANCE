using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneWP : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 1f;

    // i need to stop all movement before it happedns 

    public void UPDOWN()
        {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
