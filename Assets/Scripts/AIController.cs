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

    public enum AIStates { Idle, Spin, AttackPlayer } // These are the different states that AI can be in.
    public AIStates currentState = AIStates.Idle; // AI variable for its default state

    public float fieldOfView = 60.0f; // How much the player can see
    public float viewDistance = 10.0f; // How far the player can see
    public float hearingSensitivity = 1.0f; // How well the AI hear 
    public GameObject target; // This will track the targeting system


    public virtual void Update()
    {


        //if (isPatrolling) // If isPatrolling is running
        //{
            //DoPatrol(); // Then run DoPatrol 
        //}
    }

    
    public void DoAttackPlayer() {
        // Set player as target
        DoTargetPlayer();
        // Attack Target
        DoAttackTarget();
    }

    public void DoTargetPlayer()
    {
        // Set player as target
        target = GameManager.instance.players[0].data.gameObject;
    }

    public void DoLeadAttackTarget()
    {
        // If our target is not null
        // Move to 1 unit IN FRONT of target 
        // Shoot
    }

    public void DoAttackTarget()
    {
        // If our target is not null
        if ( target != null)
        {
            // Move to target
            data.mover.MoveTo(target.transform);

            // Shoot (Shoot is limited in fire rate)
            data.Shoot();
        }


    }

    public void DoIdle() {
        // Do Nothing!
    }

    public void Spin()
    {
        // Just rotate
        data.mover.Rotate(true);
    }

    public void TurnToFindPlayer()
    {
        // TODO: Set target as nearest player
        // TODO: Turn towards player 

    }


    public void DoShoot()
    {
        // Just shoot
        data.Shoot();
    }

    public void DoFindNearestHealthPack()
    {
        // Set target to nearest health pack
    }


    public bool CanSee( GameObject target )
    {
        // Field of View Checks 
        // Get Vector to target
        Vector3 vectorToTarget = target.transform.position - data.transform.position;
        // Get angle between forward and vectorToTarget
        float angle = Vector3.Angle(transform.forward, vectorToTarget);
        // If the player is out of the AI field of view, then stops looking for target
        if (angle > fieldOfView)
        {
            return false;
        }

        // Line of sight
        // Raycast forward for the distance
        RaycastHit hitInfo;
        // if it hit something within viewDistance
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, viewDistance))
        {
            // ... and that is not my target 
            if (hitInfo.collider.gameObject != target)
            {
                // I can't see my target
                return false;
            }
        }
        // If I made it through all the checks, then I can see the target
        return true;
    }

    public bool CanHear (GameObject target)
    {
        // Distance check 
        if (Vector3.Distance(target.transform.position, transform.position) < hearingSensitivity)
        {
            // soundmaker level check 

            // Then I can hear you
            return true;
        }

        // If I got here, I can't hear you
        return false;
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

