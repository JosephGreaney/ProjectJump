using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool paused;
    private Text text;
    private GameObject menuButton;
    private GameObject restartButton;

    void Awake()
    {
        paused = false;
        Time.timeScale = 1;
        text = GameObject.Find("TimerText").GetComponent<Text>();
        menuButton = GameObject.Find("MenuButton");
        restartButton = GameObject.Find("RestartButton");
        menuButton.SetActive(false);
        restartButton.SetActive(false);
        
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
            {
                Time.timeScale = 0;
                menuButton.SetActive(true);
                restartButton.SetActive(true);
            }

            else
            {
                Time.timeScale = 1;
                menuButton.SetActive(false);
                restartButton.SetActive(false);
            }
        }
        
    }
    
}
