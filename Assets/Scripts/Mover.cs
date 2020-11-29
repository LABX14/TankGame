using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private CharacterController cc; // This is a variable that calls for the Character Controller from the Human Controller Script 
    private ShipData data; // This grabs data from the Ship Data script

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        data = GetComponent<ShipData>();
    }

    // This determines the direction and speed the object moves
    public virtual void Move(Vector3 direction)
    {
        cc.SimpleMove(direction * data.speed);
    }

    // This determines the ships rotation
    public virtual void Rotate(bool isClockwise)
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

    public virtual void MoveTo(Transform targetTransform) { }
}
