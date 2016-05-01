using UnityEngine;
using System.Collections;

public class MenuScalar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait) //Check the phones orientation
        {
            transform.localScale = new Vector3(1.0F, 1.0F, 0.1F); //Scale to the appropriate size
        }
        else if (Screen.orientation == ScreenOrientation.Landscape)
        {                                                               //Repeat
            transform.localScale = new Vector3(2.9F, 2.7F, 0.1F);
        }
    }
}
