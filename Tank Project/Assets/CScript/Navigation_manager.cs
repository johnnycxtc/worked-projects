using UnityEngine;
using System.Collections;

public class Navigation_manager : MonoBehaviour {
	private NavMeshAgent walker;
	public Transform target;
	RaycastHit hit = new RaycastHit ();   
	RaycastHit hit1 = new RaycastHit ();   
	protected bool selected = false;
	public int first = 0;
	public GameObject flagmark;
	public GameObject flag1;
	public GameObject flag2;
	public GameObject flag3;
	public GameObject walker1;
	public GameObject walker2;
	public GameObject walker3;
	public GameObject empty;
	public GameObject selecting;
	public NavMeshAgent selectedTank = null;
	void hide(GameObject flag)
	{
		MeshRenderer[] marr = flag.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = false;
		}
	}
	// Use this for initialization
	void Start () {
		hide (flag1);
		hide (flag2);
		hide (flag3);

	}

	void activate (){
		// left click with mouse
		//if (Input.GetButtonDown ("Fire1")) {    

		if (Input.touchCount > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				// Get position of the first finger
				Vector2 touchPosition = Input.touches [0].position;
				Ray ray = Camera.main.ScreenPointToRay (touchPosition);
				//selected the raycast where mouse click
				if (Physics.Raycast (ray, out hit)) {
					//if mouse clicked a object named walker
					if (hit.collider.tag == "walker" || selecting.tag != "Untagged") {
						if (hit.collider.name == "walker1" || selecting.tag == "walker1") {
							walker = walker1.GetComponent<NavMeshAgent> ();
							selectedTank = walker;				
							selected = true;
							flagmark.gameObject.tag = walker.gameObject.name; 
						}
						if (hit.collider.name == "walker2" || selecting.tag == "walker2") {
							walker = walker2.GetComponent<NavMeshAgent> ();
							selectedTank = walker;				
							selected = true;
							flagmark.gameObject.tag = walker.gameObject.name; 
						}
						if (hit.collider.name == "walker3" || selecting.tag == "walker3") {
							walker = walker3.GetComponent<NavMeshAgent> ();
							selectedTank = walker;
							selected = true;
							flagmark.gameObject.tag = walker.gameObject.name; 
						}
					} else {
						selected = false;

					}
				}
			}
			first = 1;
		} /*else {
			walker = walker2.GetComponent<NavMeshAgent> ();
			Vector3 pointe;
			pointe.x = pointe.y = pointe.z = 0;
			walker.SetDestination (pointe);
		}*/
	}
	void go(Vector3 touchPosition){
		//set destination and walker will go there automatically
		try{
			if(selectedTank.isActiveAndEnabled){
				selectedTank.SetDestination (touchPosition);
			}
		}
		catch{
			return;
		}
	}
	// Update is called once per frame
	IEnumerator timing (Vector3 touchPosition){
		//wait 0.01 second so that target finish the location justify
		yield return new WaitForSeconds (0.01f);
		go (touchPosition);
	}
	void Update () {
		activate ();
		if(Input.touchCount <= 0) 
		{        
			return;
		}
		if (Input.touchCount > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				if (selectedTank!= null) {
					// if already selected a walker and then right click, selected walker will start moving
					Vector2 touchPosition1 = Input.touches [0].position; 
					Ray ray = Camera.main.ScreenPointToRay (touchPosition1);
					if (Physics.Raycast (ray, out hit1)) {
						if (hit1.collider.tag == "Plane") { 
							StartCoroutine (timing (hit1.point));
						}
					}
				}
			}
		}
	}
}