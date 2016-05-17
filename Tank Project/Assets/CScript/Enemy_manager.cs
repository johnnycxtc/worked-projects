using UnityEngine;
using System.Collections;

public class Enemy_manager : MonoBehaviour {
	private NavMeshAgent enemy;
	public Transform target;
	RaycastHit hit = new RaycastHit ();   
	protected bool selected = false;
	public int first = 0;
	public GameObject enemymark;
	public GameObject enemyflag1;
	public GameObject enemyflag2;
	public GameObject enemyflag3;
	public GameObject empty;
	void hide(GameObject flag)
	{
		MeshRenderer[] marr = flag.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = false;
		}
	}
	// Use this for initialization
	void Start () {
		hide (enemyflag1);
		hide (enemyflag2);
		hide (enemyflag3);
	}
	
	void activate (){
		// left click with mouse
		if (Input.GetButtonDown ("Fire1")) {     
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//selected the raycast where mouse click
			if (Physics.Raycast (ray, out hit)) {
				//if mouse clicked a object named walker
				if (hit.collider.tag == "enemy" /*|| hit.collider.name == "walker2" || hit.collider.name == "walker3"*/) {
					if (first == 1){
						//if it's same walker last time hited, do nothing
						if (enemy.name != hit.collider.name){
							enemy.GetComponent<Renderer>().material.color = Color.white;
						}
					}
					//selected walker will be selected and change color
					enemy = hit.collider.GetComponent<NavMeshAgent> ();
					hit.collider.GetComponent<Renderer>().material.color = Color.green;					
					selected = true;
					enemymark.gameObject.tag = enemy.gameObject.name; 
				} 
				else 
				{
					//if selected object is not a walker
					if(first == 0){
						return;
					}else{
						selected = false;
						enemy.GetComponent<Renderer>().material.color = Color.white;
						first =0;
					}
					enemymark.tag = empty.tag;
				}
			}
			first = 1;
		}
	}
	void go(){
		//set destination and walker will go there automatically
		enemy.SetDestination (target.position);
	}
	// Update is called once per frame
	IEnumerator timing (){
		//wait 0.01 second so that target finish the location justify
		yield return new WaitForSeconds (0.01f);
		go ();
	}
	void Update () {
		activate();
		if (selected) {
			if (Input.GetMouseButtonDown (1)) {
				// if already selected a walker and then right click, selected walker will start moving
				StartCoroutine(timing());
			}
		}
	}
}
