using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Death : MonoBehaviour {

	// Restart level by loading the level again.
	void Start () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}