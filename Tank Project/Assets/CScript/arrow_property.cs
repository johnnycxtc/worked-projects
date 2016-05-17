using UnityEngine;
using System.Collections;

public class arrow_property : MonoBehaviour {
	RaycastHit hit = new RaycastHit ();  
	public GameObject flagmark;
	public GameObject walkerflag1;
	public GameObject walkerflag2;
	public GameObject walkerflag3;
	public int movementSmoothing;
	public float speed = 60f;
	Vector3 targetPosition;
	//bool rotated = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
			{
				if(Input.touches[0].phase == TouchPhase.Began){
					if (this.gameObject.tag == flagmark.tag) {
						movementSmoothing = 1;
						Plane playerPlane = new Plane (Vector3.up, transform.position);
						Vector2 touchPosition= Input.touches[0].position;
						Ray ray = Camera.main.ScreenPointToRay (touchPosition);
						if(Physics.Raycast (ray, out hit)){
							if(hit.collider.tag == "walker"){
								return;
							}
						}
						float hitDist = 0.0f;
						if (playerPlane.Raycast (ray, out hitDist)) {
							var targetPoint = ray.GetPoint (hitDist);
							targetPosition = targetPoint;
							Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
							transform.rotation = targetRotation;
						}
				}
			}
		}

		Vector3 direction = targetPosition - transform.position;
		float distance = direction.magnitude;
		float step = speed * Time.deltaTime;
		//as long as object is away from target destination...
		if (distance > step) {
			//...move toward direction of target position at specified speed
			transform.position += direction.normalized * step;
		} else { //...otherwise...
			//...keep object at target position
			transform.position = targetPosition;
		}

	}
}
