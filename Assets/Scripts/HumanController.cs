using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HumanController : Controller
{
    

    public enum ControlType { WASD, ArrowKeys, Controller1, Controller2 }; // This gives a list of different controls to apply to the ships
    public ControlType controlType; 

    public GameObject bulletPrefab;         // Asks for a bullet prefab in the inspector
    private Transform change;               // Changes that objects transform
    public float bulletSpeed = 6f;          // This determine the player's speed
    public Transform bulletPosition;        // This gets the bulletPosition for the player
    private float shootCoolDown;            //conducts cooldown from ship data fire rate
    private bool isReadyToShoot = true;     //tracks if the ship is ready to shoot

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        change = gameObject.GetComponent<Transform>(); // the value of change is equal to Tranform of the gameobject
        shootCoolDown = data.fireRate; // The cooldown for the shot is equal to the fire rate that is from given the ShipData script.     
        GameManager.instance.players.Add(this); // Add to list of players
    }

    public void OnDestroy()
    {
        // Remove from list of players
        GameManager.instance.players.Remove(this);
    }

    // Update is called once per frame
    public void Update()
    {
        //Handle Shooting timer
        if (!isReadyToShoot) //if not ready to shoot, deduct from cooldown
        {
            //Cound down each second
            shootCoolDown -= Time.deltaTime;

            //If timer reaches 0, set isReadyToShoot and reset timer
            if (shootCoolDown <= 0)
            {
                Debug.Log("You can shoot!");
                isReadyToShoot = true;
                shootCoolDown = data.fireRate;
            }
        }
        
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
    public virtual void Shoot()
    {
        //If ready to shoot, shoot bullet and flag timer
        if (isReadyToShoot)
        {
            //Shoot bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
            bullet.GetComponent<Bullet>().myShooter = this.gameObject;
            Destroy(bullet, 2);

            //Reset isReadyToShoot until cooldown timer is complete
            isReadyToShoot = false;
        }

        //else not ready to shoot, do nothing        
        
    }
}
