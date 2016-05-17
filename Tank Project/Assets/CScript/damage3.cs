using UnityEngine;
using System.Collections;

public class damage3 : MonoBehaviour {
	public GameObject attack_mode;
	public GameObject attack_target;
	private GameObject target;
	public GameObject get_hurt;
	void fire(){
		if (get_hurt == null) {
		}
		if (attack_mode.tag == "on") {
			try {
				if (get_hurt == null){
					get_hurt = GameObject.Find (attack_target.tag);
				} else if (get_hurt.name != attack_target.tag){
					get_hurt = GameObject.Find (attack_target.tag);
				}
				if(this.gameObject.tag == "walker"){
					Enemy_property p= get_hurt.GetComponent<Enemy_property>();
					if (p != null){
						p.HP -= 15;
					}
				} else {
					walker_property p= get_hurt.GetComponent<walker_property>();
					if (p != null){
						p.HP -= 15;
					}
				}
				attack_mode.tag = "off";
			} catch {
				return;
			}
		} 
	}
	IEnumerator Ftiming (){
		yield return new WaitForSeconds (0.5f);
		fire ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (i++);
		if (attack_mode.tag == "on") {
			StartCoroutine(Ftiming());
		}
	}
}
