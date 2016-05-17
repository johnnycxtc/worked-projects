using UnityEngine;
using System.Collections;

public class DestroyItem : MonoBehaviour {
	void start(){
	}
	void OnCollisionEnter(Collision other){
		//Debug.Log ("1");
		if (other.gameObject.name == this.gameObject.tag) {
			//this.gameObject.renderer.enabled = false;
			MeshRenderer[] marr = this.GetComponentsInChildren<MeshRenderer>(true);
			foreach(MeshRenderer m in marr){
				m.enabled = false;
			}
		}
	}
}
