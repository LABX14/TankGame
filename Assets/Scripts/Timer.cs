using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeBetweenBooms; // This tracks the time between each shot
    public float countdown; // This adds a countdown after a shot 
    public float timeForNextBoom; // This tells the player when they can shoot again
    public float timeOfLastBoom;  // This tracks when the player last shot

    // Start is called before the first frame update
    void Start()
    {
        // Start our countdown at max
        countdown = timeBetweenBooms;

        // Set the time that we are allowed to boom
        timeForNextBoom = Time.time + timeBetweenBooms;

        // Set the time we last boomed
        timeOfLastBoom = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeForNextBoom + timeBetweenBooms)
        {
            // Debug.Log(" Boom ");
            // Set the time we last boomed
            timeOfLastBoom = Time.time;
        }
    }
}
