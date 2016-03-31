using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameManager;      //GameManager prefab

    /**
     *  Awake is used to instantiate game objects
     */
	void Awake ()
    {
        // Check if GameManager has already been instantiated
        if (GameManager.instance == null)
            Instantiate(gameManager);
	}
}
