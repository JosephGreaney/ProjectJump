using UnityEngine;
using System.Collections;

/* 
 * Draws a line between the scripts object and the connected body of its
 * DistanceJoint2D
*/

public class SwingingRope : MonoBehaviour {

	private Color c1 = Color.black;			// The colour of the line
	private DistanceJoint2D joint;			// The joint attached to object
	private LineRenderer lineRenderer;
	void Start() {
		joint = gameObject.GetComponent<DistanceJoint2D>();
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material.color = c1;
		lineRenderer.SetColors(c1, c1);
		lineRenderer.SetWidth(0.02F, 0.02F);
		lineRenderer.SetVertexCount(2);
	}


	void Update() {
		Vector3[] points = new Vector3[2];
		points [0] = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1f);
		points[1] = new Vector3(joint.connectedAnchor.x, joint.connectedAnchor.y, -1f);
		lineRenderer.SetPositions (points);
        lineRenderer.sortingLayerName = "Player";
    }
}
