using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool paused;
    private Text text;
    void Awake()
    {
        paused = false;
        text = GameObject.Find("TimerText").GetComponent<Text>();
    }
    void Update()
    {
        bool pressed = CrossPlatformInputManager.GetButtonDown("Pause");

        if (paused)
            text.text = "Paused";

        if (pressed)
        {
            Debug.Log(paused);
            paused = !paused;
            if (paused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
        
    }
    
}
