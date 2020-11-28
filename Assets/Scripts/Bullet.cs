using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; //This will determine the speed of the bullet when shot
    public GameObject myShooter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }


    // If the object with this script touches object tagged as enemy ship then destroy itself. 
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ShipData>())
        {
            Destroy(gameObject);
        }
    }
}
