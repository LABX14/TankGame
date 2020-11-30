using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SimpleController : AIController
{

    public GameObject target; // Test to see code will run (Will come back to change)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
         // Finite State Machine
         switch (currentState)
        {
            case AIStates.Idle:
                // Do our "update" equivalent for this state
                DoTargetPlayer();
                DoIdle();

                // Check for state changes
                if (CanSee(target)) // If the AI can see the target
                {
                    currentState = AIStates.AttackPlayer; // Then set the AI's current state to Attack
                }

                if (CanHear(target)) //If the AI can hear the target 
                {
                    currentState = AIStates.Spin; // Then set the AI's current state to turn to where they hear the player is at. 
                }
                break;

            case AIStates.Spin:
                // Do our "update" equivalent for this state
                Spin();
                // Check for state changes
                if (CanSee(target))
                {
                    currentState = AIStates.AttackPlayer;
                }
                // TODO: Exit Time
                break;

            case AIStates.AttackPlayer: 
                // Do our "update" equivalent for this state
                DoAttackPlayer();
                // Check for state changes
                if (!CanSee(target))
                {
                    currentState = AIStates.Spin;
                }
                break;
            default:
                // IF we get here, something is horribly wrong
                currentState = AIStates.Idle;
                break;

        }
    }
}
