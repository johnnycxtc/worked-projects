using UnityEngine;
using System.Collections;

public class hide : MonoBehaviour {
	public bool hideornot;
	void hide1(GameObject flag)
	{
		MeshRenderer[] marr = flag.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = false;
		}
	}
	void display(GameObject obj){
		MeshRenderer[] marr = obj.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = true;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hideornot) {
			hide1 (this.gameObject);
		} else {
			display (this.gameObject);
		}
	}
}
