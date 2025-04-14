using System.Collections.Generic;
using UnityEngine;

public class PhoneWP : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed = 3f;

    private int currentWaypointIndex = 0;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving && waypoints.Count > 0)
        {
            MoveTowardsWaypoint();
        }
    }

    void OnMouseDown() ///AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHH (kill me )
    {
        if (!isMoving && waypoints.Count > 0)
        {
            isMoving = true;
        }
    }

    void MoveTowardsWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            // Optional: stop at last waypoint
            // if (currentWaypointIndex == 0) isMoving = false;
        }
    }
}
