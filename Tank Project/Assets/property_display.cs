using UnityEngine;
using System.Collections;

public class property_display : MonoBehaviour {

	// Use this for initialization
	private Camera camera;
	//主角对象
	public GameObject walker;
	public GameObject plane;
	private int HP;
	private int acceleration;
	private int max_speed;

	void Start ()
	{
		//得到摄像机对象
		camera = Camera.main;
	}
	void update ()
	{
		HP = walker.GetComponent<walker_property> ().HP;
		HP -= 1;
	}

	void OnGUI(){
		string WHP = HP.ToString ();
		GUI.color = Color.green;
		GUI.Label(new Rect (plane.gameObject.transform.position.x+550, plane.gameObject.transform.position.z, 100, 200), walker.name+":");  
		GUI.Label(new Rect (plane.gameObject.transform.position.x+580, plane.gameObject.transform.position.z+25, 100, 200), WHP);  
	}
}

