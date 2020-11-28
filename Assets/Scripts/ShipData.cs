﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public float speed; // This determines the player's speed
    public float rotateSpeed; // This determines the player's rotate speed
    public Mover mover; // This will call the mover script 

    public float damageDone; // This track how much damage has been done
    public float shootDelay; // This determines the delay of the shot
    public float fireRate; // This will control the fire rate that the ships can fire at 

    public int maxHealth = 100; //This determines the Max Health that each ship will have
    public int curHealth = 100; //This determines the current health that will subtract when the ship takes damage

    public GameObject lastShotBy;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<ShipMover>();
        if (this.gameObject.tag == "EnemyShip")
        {
            GameManager.instance.enemyShips.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    // If the object tagged as Missile touches an object with this script (ShipData), say "I got hit in console"!
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile")
        {
            //If I am not shooting myself, conduct damage from opponent
            if (other.GetComponent<Bullet>().myShooter != this.gameObject)
            {
                lastShotBy = other.GetComponent<Bullet>().myShooter;
                curHealth -= 20;
                Debug.Log("I got hit!");
            }
        }
    }

    // Remove the object from the list game manager on the list when it is destroyed
    private void OnDestroy()
    {
        GameManager.instance.enemyShips.Remove(this);
        GameManager.instance.score += 1;
    }
}
