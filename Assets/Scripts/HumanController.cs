using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public ShipData data;

    public enum ControlType { WASD, ArrowKeys};
    public ControlType controlType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = Vector3.zero;
        if (controlType == ControlType.WASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // Move forward (+)
                directionToMove = transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                // Move backward (-)
                directionToMove = -transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate CountClockwise (-)
                data.mover.Rotate(false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                // Rotate Clockwise (+)
                data.mover.Rotate(true);
            }

            data.mover.Move(directionToMove);
        }

        if (controlType== ControlType.ArrowKeys)
        {

        }
    }
}
