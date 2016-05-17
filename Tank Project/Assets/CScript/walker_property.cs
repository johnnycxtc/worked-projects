using UnityEngine;
using System.Collections;

public class walker_property : MonoBehaviour {
	
	//主摄像机对象
	public GameObject walkerflag1;
	public GameObject walkerflag2;
	public GameObject walkerflag3;
	public GameObject flagmark;
	//public GameObject attacker_mode;
	private Camera camera;  
	//NPC名称
	//private string name = "walker";
	int maxhp;
	//主角对象
	GameObject walker;
	//NPC模型高度
	float npcHeight;
	//红色血条贴图
	public Texture2D blood_red;
	//黑色血条贴图
	public Texture2D blood_black;
	//默认NPC血值
	public int HP;
	public GameObject plane;
	void Start ()
	{
		//根据Tag得到主角对象
		walker = GameObject.FindGameObjectWithTag("walker");
		//得到摄像机对象
		camera = Camera.main;
		
		//注解1
		//得到模型原始高度
 		float size_y = GetComponent<Collider>().bounds.size. y;
		//得到模型缩放比例
		float scal_y = transform.localScale.y;
		//它们的乘积就是高度
		npcHeight = (size_y *scal_y) ;  

		if (this.gameObject.name == "walker1") { 
			HP = 150;
			maxhp = 150;
		}
		if (this.gameObject.name == "walker2") {
			HP = 150;
			maxhp = 150;
		}
		if (this.gameObject.name == "walker3") {
			HP = 150;
			maxhp = 150;
		}
	}
	
	void Update ()
	{
		//保持NPC一直面朝主角
		//transform.LookAt(walker.transform);
		if (HP <= 0) {
			//attacker_mode.tag = "off";
			if (this.gameObject.name == walkerflag1.tag){
				walkerflag1.gameObject.SetActive(false);
			} 
			else if(this.gameObject.name == walkerflag2.tag){
				walkerflag2.gameObject.SetActive(false);
			}
			else if(this.gameObject.name == walkerflag3.tag){
				walkerflag3.gameObject.SetActive(false);
			}
			this.gameObject.SetActive(false);
		}
	}

	void OnGUI()
	{
		GUI.skin.label.fontSize = 35;
		//得到NPC头顶在3D世界中的坐标
		//默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
		Vector3 worldPosition = new Vector3 (transform.position.x , transform.position.y + npcHeight,transform.position.z);
		//根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
		Vector2 position = camera.WorldToScreenPoint (worldPosition);
		//得到真实NPC头顶的2D坐标
		position = new Vector2 (position.x, Screen.height - position.y);
		//注解2
		//计算出血条的宽高 
		Vector2 bloodSize = GUI.skin.label.CalcSize (new GUIContent(blood_red));
		//通过血值计算红色血条显示区域
		int blood_width = blood_red.width * HP/maxhp;
		//先绘制黑色血条
		GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2),position.y - bloodSize.y -40,bloodSize.x,bloodSize.y),blood_black);
		//在绘制红色血条
		GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2),position.y - bloodSize.y -40,blood_width,bloodSize.y),blood_red);

		Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (name));
		//设置显示颜色为黄色
		GUI.color = Color.green;
		//绘制NPC名称
		//Debug.Log (touchPosition.x);
		GUI.Label (new Rect (position.x - (nameSize.x / 2), position.y - nameSize.y - bloodSize.y - 45, nameSize.x, nameSize.y), name);
	}
}

