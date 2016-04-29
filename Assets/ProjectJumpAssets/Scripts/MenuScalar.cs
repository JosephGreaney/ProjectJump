using UnityEngine;
using System.Collections;

public class MenuScalar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait && transform.localScale.x == 1.5f)
        {
            print("portrait");
            transform.localScale += new Vector3(-0.5F, -0.5F, 0);
        }
        else if (Screen.orientation == ScreenOrientation.Landscape && transform.localScale.x == 1.4f)
        {
            transform.localScale += new Vector3(0.5F, 0.5F, 0);
        }
    }
}
