using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighScore : DBConnect {

    static string highscore;
    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = getBestTime();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
