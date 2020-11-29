using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{

    public ShipData data; // The Ship my AI controls
    public List<Waypoint> waypoints;
    public int currentWaypointIndex = 0;
    public float closeEnoughForWaypoints = 0.1f;

    public enum PatrolType { Stop, Loop, PingPong, Random }
    public PatrolType patrolType;
    public bool isPatrolling = true;
    public bool isPatrolForward = true;

    public void Update()
    {
        if (isPatrolling)
        {
            DoPatrol();
        }
    }

    public void DoShoot()
    {

    }

    public void DoFindNearestHealthPack()
    {

    }


    public void DoPatrol()
    {
        // Turn towards our waypoint and Move forward
       
        data.mover.MoveTo(waypoints[currentWaypointIndex].transform);

        // If we are "close enough" to the waypoint, advance to the next waypoint
        if (Vector3.Distance(data.transform.position, waypoints[currentWaypointIndex].transform.position) < closeEnoughForWaypoints)
        {
            if (isPatrolForward)
            {
                currentWaypointIndex = currentWaypointIndex + 1;
            }
            else
            {
                currentWaypointIndex = currentWaypointIndex - 1;
            }
            

        }

        // Loop End
        if (currentWaypointIndex >= waypoints.Count)
        {
            if (patrolType == PatrolType.Loop)
            {
                // Next waypoint is 0 again
                currentWaypointIndex = 0;
            }
            else if (patrolType == PatrolType.Random)
            {
                // Next waypoint is Random
                currentWaypointIndex = Random.Range(0, waypoints.Count);
            }
            else if (patrolType == PatrolType.Stop)
            {
                // Stop Patrolling
                isPatrolling = false;
            }
            else if (patrolType == PatrolType.PingPong)
            {
                // Start moving in the opposite direction
                isPatrolForward = !isPatrolForward;
                // Make sure our waypoints are within range
                currentWaypointIndex = Mathf.Clamp(currentWaypointIndex, 1, waypoints.Count);
            }
        }
    }
}
