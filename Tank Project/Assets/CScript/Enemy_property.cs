using UnityEngine;
using System.Collections;

public class Enemy_property : MonoBehaviour {
	
	//主摄像机对象
	public GameObject enemyflag1;
	public GameObject enemyflag2;
	public GameObject enemyflag3;
	private Camera camera;
	private GameObject thisg;
	private NavMeshAgent enemyself;
	public Transform target;
	public GameObject attack_mode;
	RaycastHit hit = new RaycastHit ();   
	Vector2 touchPosition;
	//NPC名称
	//private string name = "walker";
	
	//主角对象
	GameObject enemy;
	//NPC模型高度
	float npcHeight;
	//红色血条贴图
	public Texture2D blood_red;
	//黑色血条贴图
	public Texture2D blood_black;
	//默认NPC血值
	public int HP = 200;
	void hide(GameObject flag)
	{
		MeshRenderer[] marr = flag.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = false;
		}
	}
	void display(GameObject flag)
	{
		MeshRenderer[] marr = flag.GetComponentsInChildren<MeshRenderer> (true);
		foreach (MeshRenderer m in marr) {
			m.enabled = true;
		}
	}
	void Start ()
	{
		//hide (this.gameObject);
		//根据Tag得到主角对象
		enemy = GameObject.FindGameObjectWithTag("enemy");
		//得到摄像机对象
		camera = Camera.main;
		
		//注解1
		//得到模型原始高度
		float size_y = GetComponent<Collider>().bounds.size. y;
		//得到模型缩放比例
		float scal_y = transform.localScale.y;
		//它们的乘积就是高度
		npcHeight = (size_y *scal_y) ;
		thisg = this.gameObject;
		enemyself = thisg.GetComponent<NavMeshAgent> ();
		//enemyself.SetDestination (target.position);
	}
	void go(){
		//set destination and walker will go there automatically
		try{
			//enemyself.SetDestination (target.position);
		}
		catch{
			return;
		}
	}
	// Update is called once per frame
	IEnumerator timing (){
		//wait 0.01 second so that target finish the location justify
		if (this.gameObject.name == "enemy1") {
			yield return new WaitForSeconds (1.50f);
			go ();
		} 
		if (this.gameObject.name == "enemy2") {
			yield return new WaitForSeconds (2.50f);
			go ();
		} 
		if(this.gameObject.name == "enemy3") {
			yield return new WaitForSeconds (3.50f);
			go ();
		}

	}
	void Update ()
	{
		//Debug.Log (touchPosition);
		if (attack_mode.tag == "on") {
			display (this.gameObject);
		} else  {
			//hide (this.gameObject);
		}
		StartCoroutine(timing());
		if (HP <= 0) {
			//attacker_mode.tag = "off";
			if (this.gameObject.name == enemyflag1.tag){
				enemyflag1.gameObject.SetActive(false);
			} 
			else if(this.gameObject.name == enemyflag2.tag){
				enemyflag2.gameObject.SetActive(false);
			}
			else if(this.gameObject.name == enemyflag3.tag){
				enemyflag3.gameObject.SetActive(false);
			}
			this.gameObject.SetActive(false);
		}
		if (Input.touchCount > 0) {
			touchPosition = Input.GetTouch (0).position;
			Ray ray = Camera.main.ScreenPointToRay (touchPosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider == this.gameObject) { 
					HP -= 5;
				}
			}
		}
	}
	void onGUI()
	{

			//得到NPC头顶在3D世界中的坐标
			//默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
			Vector3 worldPosition = new Vector3 (transform.position.x, transform.position.y + npcHeight, transform.position.z);
			//根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
			Vector2 position = camera.WorldToScreenPoint (worldPosition);
			//得到真实NPC头顶的2D坐标
			position = new Vector2 (position.x, Screen.height - position.y);
			//注解2
			//计算出血条的宽高
			Vector2 bloodSize = GUI.skin.label.CalcSize (new GUIContent (blood_red));
			//通过血值计算红色血条显示区域
			int blood_width = blood_red.width * HP / 100;
			//先绘制黑色血条
			GUI.DrawTexture (new Rect (position.x - (bloodSize.x / 2), position.y - bloodSize.y - 30, bloodSize.x, bloodSize.y), blood_black);
			//在绘制红色血条
			GUI.DrawTexture (new Rect (position.x - (bloodSize.x / 2), position.y - bloodSize.y - 30, blood_width, bloodSize.y), blood_red);
		
			//注解3
			//计算NPC名称的宽高
		if (touchPosition.x != 0){
			Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent (name));
			//设置显示颜色为黄色
			GUI.color = Color.green;
			//绘制NPC名称
			Debug.Log (touchPosition.x);
			GUI.Label (new Rect (position.x - (nameSize.x / 2), position.y - nameSize.y - bloodSize.y - 25, nameSize.x, nameSize.y), name);
			Debug.Log (touchPosition);
		}
	}
	
	//下面是经典鼠标点击对象的事件，大家看一下就应该知道是什么意思啦。
	void OnMouseDrag ()
	{
		//Debug.Log("鼠标拖动该模型区域时");
	}
	
	void OnMouseDown()
	{
		//Debug.Log("鼠标按下时");
		
	}
	void OnMouseUp()
	{
		//Debug.Log("鼠标抬起时");
	}
	
	void OnMouseEnter()
	{
		//Debug.Log("鼠标进入该对象区域时");
	}
	void OnMouseExit()
	{
		//Debug.Log("鼠标离开该模型区域时");
	}
	void OnMouseOver()
	{
		//Debug.Log("鼠标停留在该对象区域时");
	}
	
}

