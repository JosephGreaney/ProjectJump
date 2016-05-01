using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	public void GoToMenu()
    {
        Debug.Log("GO TO MENU");
        SceneManager.LoadScene("Menu");
    }
}
