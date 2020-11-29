using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : Mover
{
    private CharacterController cc; // This is a variable that calls for the Character Controller from the Human Controller Script 
    private ShipData data; // This grabs data from the Ship Data script

    // Start is called before the first frame update
    void Start ()
    {
        cc = GetComponent<CharacterController>();
        data = GetComponent<ShipData>();
    }

    // This determines the direction and speed the object moves
    public override void Move ( Vector3 direction)
    {
        cc.SimpleMove( direction * data.speed);
    }

    // This determines the ships rotation
    public override void Rotate ( bool isClockwise)
    {
        if (isClockwise)
        {
            transform.Rotate(new Vector3(0, data.rotateSpeed * Time.deltaTime, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -data.rotateSpeed * Time.deltaTime, 0));
        }
    }

    public override void MoveTo(Transform targetTransform)
    {
        // Rotate twoards the transform 
        RotateTowards(targetTransform);

        // Move forwards
        cc.SimpleMove(transform.forward * data.speed);
    }

    public void RotateTowards(Transform targetTransform)
    {

        Vector3 targetPosition = targetTransform.position;
        targetPosition.y = transform.position.y;


        // Rotate Towards that object 
        // Find the vector from us to our target 
        Vector3 targetVector = targetTransform.position - transform.position;
        // Find the rotation to look down that vector 
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        // Find a rotation that PARTWAY closer to that rotation than we are right now
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, data.rotateSpeed);
        // Change to that new rotation
        transform.rotation = newRotation;
    }


}
