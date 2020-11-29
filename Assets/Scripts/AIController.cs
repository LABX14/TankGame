using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{

    public ShipData data; // Gives data from ShipData
    public List<Waypoint> waypoints; // This allows the player to create a list of the waypoints in the scene. 
    public int currentWaypointIndex = 0; // This creates 
    public float closeEnoughForWaypoints = 0.1f; // Set closeEnoughWaypoints value to 0.1f

    public enum PatrolType { Stop, Loop, PingPong, Random } // Create a drop down list of the different types of Patrol for the AI 
    public PatrolType patrolType; // Set PatrolType to patrolType
    public bool isPatrolling = true; // Set isPatrolling to true. isPatrolling means that the AI is currently patrolling
    public bool isPatrolForward = true; // Set isPatrolForward to true. isPatrolForward means that the AI is patrolling and moving forward

    public void Update()
    {
        if (isPatrolling) // If isPatrolling is running
        {
            DoPatrol(); // Then run DoPatrol 
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
            if (isPatrolForward) // Checks to see if isPatrolForward is being called 
            {
                currentWaypointIndex = currentWaypointIndex + 1; // Then add 1 to currentWaypointIndex value
            }
            else 
            {
                currentWaypointIndex = currentWaypointIndex - 1; // Else subtract 1 from currentWaypointIndex current value
            }
        }

        // Loop End (When index goes out of range)
        if (currentWaypointIndex > waypoints.Count - 1 || currentWaypointIndex < 0)
        {
            if (patrolType == PatrolType.Loop) // Check to see if patrolType and PatrolType.Loop have equal value. 
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
                currentWaypointIndex = Mathf.Clamp(currentWaypointIndex, 1, waypoints.Count - 1);
            }
        }
    }
}

