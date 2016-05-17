using UnityEngine;
using System.Collections;

public class Tank_TurnHeaD : MonoBehaviour {
	public GameObject target;
	public Transform body;
	public GameObject attack_mode;
	//public int moveSpeed;
	public int rotateSpeed;
	private Transform mytransform;
	public GameObject shooting_target;

	void Update(){
		if (attack_mode.tag != "on") {
			return;
		}
		if (attack_mode.tag == "on") {
			try{
				target = GameObject.Find (shooting_target.gameObject.tag);
				Debug.DrawLine(target.transform.position,this.transform.position,Color.black);

				//Debug.Log(target.name);
				Quaternion TargetRotation = Quaternion.LookRotation (target.transform.position - transform.position, Vector3.up);
				//Debug.Log (TargetRotation);
				body.rotation = Quaternion.Slerp (body.rotation, TargetRotation, rotateSpeed * Time.deltaTime);
				//body.rotation=Quaternion.Slerp(body.rotation,Quaternion.LookRotation(target.transform.position-mytransform.position),rotateSpeed*Time.deltaTime);
				//body.Rotate(TargetRotation);
				//Debug.Log("1");
			}
			catch{
				attack_mode.tag = "off";
				return;
			}
		}
	}
		//Move towards target
		//mytransform.position += mytransform.forward*moveSpeed* Time.deltaTime;
}
