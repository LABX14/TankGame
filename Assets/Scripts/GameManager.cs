using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // This is an instance variable from the game manager
    public int score; // This adds a score to the player 
    public GameObject player; // This grabs the player 
    public GameObject playerPrefab; // This grabs the player's prefab

    public List<ShipData> enemyShips; // This is a enemy ship variable that will be applied to a list
    public List<Controller> players;

    private void Awake()
    {
        if (instance == null) // If the instance has same value as null
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // This add the number of enemy ships to a list
        enemyShips = new List<ShipData>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
