using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public void ChangeToScene (int sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);
	}
}
