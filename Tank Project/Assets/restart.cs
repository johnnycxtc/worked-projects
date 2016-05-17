using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {
	RaycastHit hit = new RaycastHit (); 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				// Get position of the first finger
				Vector2 touchPosition = Input.touches [0].position;
				Ray ray = Camera.main.ScreenPointToRay (touchPosition);
				//selected the raycast where mouse click
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider == this.gameObject) {
						Application.LoadLevel ("new tank world");
					}
				}
			}
		}
	}
}
