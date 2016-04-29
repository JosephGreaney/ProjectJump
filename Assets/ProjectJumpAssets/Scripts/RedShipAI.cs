using UnityEngine;
using System.Collections;

public class RedShipAI : Movement {

    //setting the target and movement speed
    public Transform target;
    public float speed = 2f;
    public float range = 15f; 
    GameObject player;
    public Rigidbody2D redShip;

	void Start () {
        redShip = GetComponent<Rigidbody2D>();
        //Finding position and target
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) < range && player.transform.position.y > transform.position.y)
        {
            transform.LookAt(player.transform);
            if (transform.position.x > player.transform.position.x)  //Checking if the player is in range
            {                                                        //Then check which direction he is in relative to the enemy
                moveUpLeft(speed, redShip);                          //Then call a function to m ove in that direction
            }
            if (transform.position.x < player.transform.position.x)
            {
  
                moveUpRight(speed, redShip);
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) < range && player.transform.position.y < transform.position.y)
        {
            if (transform.position.x > player.transform.position.x)
            {
                moveDownLeft(speed, redShip);
            }
            if (transform.position.x < player.transform.position.x)
            {
                moveDownRight(speed, redShip);
            }
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 20)
        {
            stopMoving(redShip);
        }
        //Sets the sprite to be at a set rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
