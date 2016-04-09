using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour {

    public float speed = 0.2f;
    private bool move = false;
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (move)
        {
            //Keep moving left
            transform.position = new Vector3(transform.position.x - (speed), transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            GameManager.PlayerDeath();
    }

    void Move()
    {
        move = true;
    }
}
