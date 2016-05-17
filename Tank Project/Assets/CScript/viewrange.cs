using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class viewrange : MonoBehaviour {
	RaycastHit hit = new RaycastHit (); 
	public int pointCount = 10;
	public float radius = 30f;
	private float angle;
	private List<Vector3> points=new List<Vector3>();
	private LineRenderer renderer;
	private bool rendering = false;  //用于标识是否显示
	public bool find = false;
	public GameObject attack_mode;
	public GameObject attack_target;
	//public GameObject get_hurt;
	//public GameObject attacker;
	// Use this for initialization
	void display(GameObject obj){
		MeshRenderer[] marr = obj.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = true;
		}
	}
	void Start () {
		angle = 360f / pointCount;
		renderer = GetComponent<LineRenderer>();
		if(!renderer)
		{
			Debug.LogError("LineRender is NULL!");
		}
	}
	
	void CalculationPoints()
	{
		Vector3 v=transform.position+transform.forward*radius;
		v.y += 2;
		points.Add(v);
		Quaternion r = transform.rotation;
		for(int i=1;i<pointCount;i++)
		{
			Quaternion q = Quaternion.Euler(r.eulerAngles.x, r.eulerAngles.y - (angle * i), r.eulerAngles.z);
			v = transform.position + (q * Vector3.forward) * radius;
			v.y+=2;
			points.Add(v);
		}
	}

	private  float triangleArea(float v0x,float v0y,float v1x,float v1y,float v2x,float v2y) 
	{
		return Mathf.Abs((v0x * v1y + v1x * v2y + v2x * v0y
		                  - v1x * v0y - v2x * v1y - v0x * v2y) / 2f);
	}

	bool IsInRange(Vector3 point,Vector3 v0,Vector3 v1,Vector3 v2)
	{
		float x = point.x;
		float y = point.z;
		
		float v0x = v0.x;
		float v0y = v0.z;
		
		float v1x = v1.x;
		float v1y = v1.z;
		
		float v2x = v2.x;
		float v2y = v2.z;
		
		float t = triangleArea(v0x,v0y,v1x,v1y,v2x,v2y);
		float a = triangleArea(v0x,v0y,v1x,v1y,x,y) + triangleArea(v0x,v0y,x,y,v2x,v2y) + triangleArea(x,y,v1x,v1y,v2x,v2y);
		
		if (Mathf.Abs(t - a) <= 0.01f) 
		{
			return true;
		}else 
		{
			return false;
		}
	}
	void DrowPoints()
	{
		//Vector3 point = target.transform.position;
		for(int i=0;i<points.Count;i++)
		{
			Debug.DrawLine(this.transform.position, points[i], Color.green);
			if (i < points.Count-1){
				Debug.DrawLine(points[i],points[i+1],Color.red);
			}else{
				Debug.DrawLine(points[0],points[i],Color.red);
			}
			renderer.SetPosition(i, points[i]);
		}
		if (points.Count > 0)   //这里要说明一下，因为圆是闭合的曲线，最后的终点也就是起点，
			renderer.SetPosition(pointCount, points[0]);
	}
	void ClearPoints()
	{
		points.Clear();  ///清除所有点
	}

		
	

	// Update is called once per frame
	void Update () {
		find = false;
		rendering = true; 

		if(rendering)
		{
			renderer.SetVertexCount(pointCount + 1);  ///这里是设置圆的点数，加1是因为加了一个终点（起点）
			CalculationPoints();
			DrowPoints();
		}
		else
		{
			renderer.SetVertexCount(0);//不显示时设置圆的点数为0
			
		}
		ClearPoints();
	}
}