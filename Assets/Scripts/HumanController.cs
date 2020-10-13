using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public ShipData data;

    public enum ControlType { WASD, ArrowKeys, Controller1, Controller2 };
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
                directionToMove = data.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                // Move backward (-)
                directionToMove = -data.transform.forward;
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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Move forward (+)
                directionToMove = data.transform.forward;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                // Move backward (-)
                directionToMove = -data.transform.forward;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Rotate CountClockwise (-)
                data.mover.Rotate(false);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // Rotate Clockwise (+)
                data.mover.Rotate(true);
            }
            data.mover.Move(directionToMove);
        }

        if (controlType == ControlType.Controller1)
        {
            if (Input.GetAxis("Vertical1") > 0.5)
            {
                // Move forward (+)
                directionToMove = data.transform.forward;
            }
            if (Input.GetAxis("Vertical1") > -0.5)
            {
                // Move backward (-)
                directionToMove = -data.transform.forward;
            }
            if (Input.GetAxis("Horizontal1") < -0.5)
            {
                // Rotate CountClockwise (-)
                data.mover.Rotate(false);
            }
            if (Input.GetAxis("Horizontal1") > 0.5)
            {
                // Rotate Clockwise (+)
                data.mover.Rotate(true);
            }
            data.mover.Move(directionToMove);
        }
    }
}
