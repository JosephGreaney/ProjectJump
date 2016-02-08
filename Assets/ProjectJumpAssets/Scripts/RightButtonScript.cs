using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using System;

/*
 * This script handles the user input for the Right button.
 * The script checks if either the right or left button are pressed and then checks
 * to see if the right button is being hovered on to set the player's movement to 
 * moving to the right. This allows for quick switching between left and right without
 * making the player release either button. It also allows for instant stopping if
 * the player stops pressing either button.
*/
public class RightButtonScript : MoveButton, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool hover = false;         // Whether the button is hovered over or not
    private bool lPressed = false;      // Whether the left button is pressed or not
    public string Name = "Right";       // The name of the button for CrossPlatformInput
    public GameObject leftButton;       // The RightButton object in the scene

    // Use this for initialization
    void Start()
    {
        //Find the corresponding left button in the scene
        leftButton = GameObject.Find("LeftButton");
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the left button is pressed
        lPressed = leftButton.GetComponent<LeftButtonScript>().getPressed();
        // If either button are pressed and the button is hovered over then set button to down
        if ((lPressed || pressed )&& hover)
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
