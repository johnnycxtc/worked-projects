using UnityEngine;
using System.Collections;

public class Enemy_clicktomove : MonoBehaviour {
	public GameObject enemymark;
	public int movementSmoothing;
	public float speed = 60f;
	public GameObject enemyflag1;
	public GameObject enemyflag2;
	public GameObject enemyflag3;

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
		if (Input.GetMouseButtonDown (1)) {
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
			if (enemymark.gameObject.tag == enemyflag1.tag) {
				display(enemyflag1);
				enemyflag1.transform.Rotate (270,0,0);	
			}else if (enemymark.gameObject.tag == enemyflag2.tag) {
				display(enemyflag2);
				enemyflag2.transform.Rotate (270,0,0);	
			}else if (enemymark.gameObject.tag == enemyflag3.tag) {
				display(enemyflag3);
				enemyflag3.transform.Rotate (270,0,0);	
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