﻿using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * This class is used to handle the collision detection for boxes that kill the player
 * when the player collides with this script's trigger box then the scene is restarted
 */
public class OnDeathBox : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
    // If the player collides with the trigger box then the scene is restarted
	void OnTriggerEnter2D(Collider2D other) {
        
		if (other.tag == "Player") {
            GameManager.PlayerDeath();
        }
	}
}
