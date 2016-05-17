using UnityEngine;
using System.Collections;

public class clicktomove : MonoBehaviour
{
	public GameObject flagmark;
	public int movementSmoothing;
	public float speed = 60f;
	public GameObject walkerflag1;
	public GameObject walkerflag2;
	public GameObject walkerflag3;
	Vector3 targetPosition;
	//public GameObject arrow;
	void start(){
		//arrowTarget.gameObject.SetActive (false);
	}
	void display(GameObject obj){
		MeshRenderer[] marr = obj.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = true;
		}
	}
	void Update()
	{	
		if (Input.touchCount > 0) {
			movementSmoothing = 1;
			Plane playerPlane = new Plane (Vector3.up, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			float hitDist = 0.0f;
			if (playerPlane.Raycast (ray, out hitDist)) {
				var targetPoint = ray.GetPoint (hitDist);
				targetPosition = targetPoint;
				Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
				transform.rotation = targetRotation;
			}
			if (flagmark.gameObject.tag == "walker1") {
				display(walkerflag1);
				//walkerflag1.transform.Rotate (270,0,0);
			}
			else if (flagmark.gameObject.tag == "walker2") {
				display(walkerflag2);
				//walkerflag2.transform.Rotate (270,0,0);
			}
			else if (flagmark.gameObject.tag == "walker3") {
				display(walkerflag3);
				//walkerflag3.transform.Rotate (270,0,0);
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