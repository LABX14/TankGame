using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HumanController : MonoBehaviour
{
    public ShipData data;

    public enum ControlType { WASD, ArrowKeys, Controller1, Controller2 };
    public ControlType controlType;

    public GameObject bulletPrefab;
    private Transform change;
    public float bulletSpeed = 6f;
    public Transform bulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        change = gameObject.GetComponent<Transform>();

         
    }

    // Update is called once per frame
    void Update()
    {
        // This will allow the player use WASD to move the ship. 
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

        // This will allow the player to use the arrow keys to move the ship.
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

        // This will allow the player to use a controller to move the ship. 
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

        //If this spacebar is pressed, then call for Shoot. 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // This will spawn the bullet and have it shoot from the ship
    public void Shoot()
    {
        Debug.Log("pew pew");
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Destroy(bullet, 2);
        
    }
}
