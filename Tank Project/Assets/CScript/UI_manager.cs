using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class UI_manager : MonoBehaviour { 
	
	private string a; 
	public GameObject walker;
	public GameObject flagmark;
	// Use this for initialization 
	
	void Update () { 
		Text text = this.GetComponent<Text> (); 
		if (walker.activeSelf) {
			if (flagmark.tag == walker.gameObject.name) {
				text.color = Color.white;
			} else {
				text.color = Color.green;
			}
			int hp = walker.GetComponent<walker_property> ().HP;
			float acceleration = walker.GetComponent<NavMeshAgent> ().acceleration;
			float max_speed = walker.GetComponent<NavMeshAgent> ().speed;
			a = walker.gameObject.name + ": \n HP: " + hp.ToString () + "\n Acceleration: " + acceleration.ToString () + "\n Max Speed: " + max_speed.ToString ();
			text.text = a; 
		} else {
			text.color = Color.red;
			a = walker.gameObject.name + " Shut Done";
			text.text = a;
		}
	}
} 