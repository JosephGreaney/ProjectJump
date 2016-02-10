using UnityEngine;
using UnityEngine.EventSystems;

/*
 * This class is used to handle the pressing of the movement buttons
 * if the button is pressed then pressed is set to true and when the button
 * is depressed pressed is set to false
*/
public class MoveButton : MonoBehaviour
{
    
    protected bool pressed = false;     // Whether the button is pressed or not

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public bool getPressed()
    {
        return pressed;
    }
}

