using UnityEngine;
using System.Collections;

public class win_test : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject walker1;
	public GameObject walker2;
	public GameObject walker3;
	public GameObject plane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.skin.label.fontSize = 40;
		GUI.color = Color.green;
		GUI.Label (new Rect (plane.gameObject.transform.position.x + 1450, plane.gameObject.transform.position.z + 900, 400, 800), "Enemy Information:");  
		GUI.Label (new Rect (plane.gameObject.transform.position.x + 1500, plane.gameObject.transform.position.z + 945, 400, 800), "HP: 150");  
		GUI.Label (new Rect (plane.gameObject.transform.position.x + 1500, plane.gameObject.transform.position.z + 985, 400, 800), "Attack: 15-15");  
		GUI.skin.label.fontSize = 40;
		GUI.color = Color.red;
		if (!enemy1.activeSelf) {
			GUI.Label (new Rect (plane.gameObject.transform.position.x + 1450, plane.gameObject.transform.position.z + 700, 400, 800), "Enemy1 shut down.");  
		}
		if (!enemy2.activeSelf) {
			GUI.Label (new Rect (plane.gameObject.transform.position.x + 1450, plane.gameObject.transform.position.z + 750, 400, 800), "Enemy2 shut down.");  
		}
		if (!enemy3.activeSelf) {
			GUI.Label (new Rect (plane.gameObject.transform.position.x + 1450, plane.gameObject.transform.position.z + 800, 400, 800), "Enemy3 shut down.");  
		}

	}
}
