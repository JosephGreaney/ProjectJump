using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime); //rotates 30 degress per second
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");
            seeker.SendMessage("Move");
            GameObject blueLaser = GameObject.FindGameObjectWithTag("BlueLaser");
            blueLaser.SetActive(false);
        }
    }
}
