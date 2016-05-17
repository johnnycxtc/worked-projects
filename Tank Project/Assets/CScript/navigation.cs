using UnityEngine;
using System.Collections;

public class navigation : MonoBehaviour {
	private NavMeshAgent walker;
	public Transform target;
	RaycastHit hit = new RaycastHit ();   
	protected bool selected = false;
	// Use this for initialization
	void Start () {
		walker = gameObject.GetComponent<NavMeshAgent> ();
	}
	void activate (){
		if (Input.GetButtonDown ("Fire1"))  {
			//Debug.Log ("1");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Debug.Log ("2");
			if (Physics.Raycast (ray, out hit)) {
				//Debug.Log ("3");
				if (hit.collider.name == "walker1") {
					//Debug.Log ("4");
					selected = true;
				} else {
					selected = false;
				}
			}
		}
	}

	void OnMouseDown(){ 

		//selected = true;   
	}
	// Update is called once per frame
	void Update () {
		 InvokeRepeating("activate", 1,5);
		if (selected) {
			walker.SetDestination (target.position);
		}
	}
}
