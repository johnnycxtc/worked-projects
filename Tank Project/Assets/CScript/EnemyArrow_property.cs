using UnityEngine;
using System.Collections;

public class EnemyArrow_property : MonoBehaviour {
	public GameObject enemymark;
	public GameObject enemyflag1;
	public GameObject enemyflag2;
	public GameObject enemyflag3;
	public int movementSmoothing;
	public float speed = 60f;
	Vector3 targetPosition;
	//bool rotated = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.tag == enemymark.tag) {
			if (Input.GetMouseButtonDown (1)) {
				//Debug.Log ("3");
				movementSmoothing = 1;
				Plane playerPlane = new Plane (Vector3.up, transform.position);
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float hitDist = 0.0f;
				if (playerPlane.Raycast (ray, out hitDist)) {
					var targetPoint = ray.GetPoint (hitDist);
					targetPosition = targetPoint;
					Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
					transform.rotation = targetRotation;
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
