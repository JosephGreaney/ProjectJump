using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");
            seeker.SendMessage("Move");
            GameObject endPickUp = GameObject.FindGameObjectWithTag("PickUp");
            endPickUp.gameObject.SetActive(true);
        }
    }
}
