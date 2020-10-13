using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public Mover mover;
    public float damageDone;
    public float shootDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<ShipMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
