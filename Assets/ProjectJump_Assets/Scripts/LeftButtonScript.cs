using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using System;

public class LeftButtonScript : MoveButton, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

    private bool hover = false;
    private bool rPressed = false;
    public string Name = "Left";
    public GameObject rightButton;

    // Use this for initialization
    void Start () {
        rightButton = GameObject.Find("RightButton");
        
    }
	
	// Update is called once per frame
	void Update () {
        rPressed = rightButton.GetComponent<RightButtonScript>().getPressed();

        if ((rPressed || pressed) && hover)
        {

            CrossPlatformInputManager.SetButtonDown(Name);
        }
        else
        {
            CrossPlatformInputManager.SetButtonUp(Name);
        }
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }
}
