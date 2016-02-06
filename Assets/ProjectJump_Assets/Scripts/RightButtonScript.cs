using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using System;

public class RightButtonScript : MoveButton, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool hover = false;
    private bool lPressed = false;
    public string Name = "Right";
    public GameObject leftButton;

    // Use this for initialization
    void Start()
    {
        leftButton = GameObject.Find("LeftButton");
    }

    // Update is called once per frame
    void Update()
    {
        lPressed = leftButton.GetComponent<LeftButtonScript>().getPressed();
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
