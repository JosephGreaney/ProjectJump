using UnityEngine;
using System.Collections;

public class BlueShipAI : Movement {

    //setting the target and movement speed
    public Transform target;
    public float speed = 7.5f;
    GameObject player;
    public Rigidbody2D blueShip;

    void Start () {
        //Finding position and target
        blueShip = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance (transform.position, player.transform.position) > 0 && Vector3.Distance(transform.position, player.transform.position) < 20) { //Check if player is in range
            if (player.transform.position.x > transform.position.x) // If he is to the left or right
            {
                transform.LookAt(player.transform);
                moveRight(speed, blueShip);
            }
            if (player.transform.position.x < transform.position.x)
            {
                transform.LookAt(player.transform);
                moveLeft(speed, blueShip);
            }
        }
        else
        {
            stopMoving(blueShip);
        }

        //Sets the sprite to be at a set rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
