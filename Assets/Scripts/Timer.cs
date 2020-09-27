using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeBetweenBooms;
    public float countdown;
    public float timeForNextBoom;
    public float timeOfLastBoom;

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
            Debug.Log(" Boom ");
            // Set the time we last boomed
            timeOfLastBoom = Time.time;
        }
    }
}
