using UnityEngine;
using System.Collections;
using UnityEngine.Events;//引用事件命名空间
using UnityEngine.UI;//引用UI命名空间

public class walker_button_click : MonoBehaviour 
{
	public GameObject selecting;
	
	public void ChangeTheSelect1( )
	{
		selecting.tag = "walker1";
	}
	public void ChangeTheSelect2( )
	{
		selecting.tag = "walker2";
	}
	public void ChangeTheSelect3( )
	{
		selecting.tag = "walker3";
	}
}