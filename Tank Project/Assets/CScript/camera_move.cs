using UnityEngine;
using System.Collections;

public class camera_move : MonoBehaviour {
	public Transform walker1;
	public Transform walker2;
	public Transform walker3;
	public GameObject flagmark;
	//public Transform character;   //摄像机要跟随的人物 

	public float smoothTime = 0.01f;  //摄像机平滑移动的时间     
	private Vector3 cameraVelocity = Vector3.zero;     
	private Camera mainCamera;
	void  Awake (){   
		mainCamera = Camera.main;     
	}  
	void  Update(){ 
		if (flagmark.tag == "walker1") {
			transform.position = Vector3.SmoothDamp (transform.position, walker1.position + new Vector3 (-10, 700, -200), ref cameraVelocity, smoothTime);    
		}
		if (flagmark.tag == "walker2") {
			transform.position = Vector3.SmoothDamp (transform.position, walker2.position + new Vector3 (-10, 700, -200), ref cameraVelocity, smoothTime);    
		}
		if (flagmark.tag == "walker3") {
			transform.position = Vector3.SmoothDamp (transform.position, walker3.position + new Vector3 (-10, 700, -200), ref cameraVelocity, smoothTime);    
		}
	}
}