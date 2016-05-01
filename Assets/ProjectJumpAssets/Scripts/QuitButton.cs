using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
