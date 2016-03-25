using UnityEngine;
using System.Collections;

public class RedShipAI : Movement {

    //setting the target and movement speed
    public Transform target;
    public float speed = 2f;
    GameObject player;
    public Rigidbody2D redShip;

	// Use this for initialization
	void Start () {
        redShip = GetComponent<Rigidbody2D>();
        //Finding position and target
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //print(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 20 && player.transform.position.y > transform.position.y)
        {
            print("working");
            transform.LookAt(player.transform);
            if (transform.position.x > player.transform.position.x)
            {
                print("still working");
                moveUpLeft(speed, redShip);
            }
            if (transform.position.x < player.transform.position.x)
            {
  
                moveUpRight(speed, redShip);
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 20 && player.transform.position.y < transform.position.y)
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
        //Sets the sprite to be at a set rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
