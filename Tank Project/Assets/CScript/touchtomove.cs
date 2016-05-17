using UnityEngine;
using System.Collections;

//moves object to mouse's current position
//This is a conversion of a JavaScript found in this YT video: 
// http://www.youtube.com/watch?v=PCrWFEclFBw&list=WL6F88382411E54CDA
// Please, give this person support with his videos

public class touchtomove : MonoBehaviour
{
	
	public int movementSmoothing;
	public float speed = 60f;
	Vector3 targetPosition;
	
	void Update()
	{
		if(Input.touchCount <= 0) 
		{        
			return;
		}
		if (Input.touchCount > 0) {
			// if already selected a walker and then right click, selected walker will start moving
			Vector2 touchPosition1= Input.touches[0].position;
			Vector3 realtarpo = Camera.main.ScreenToWorldPoint(touchPosition1);
			movementSmoothing = 1;
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			Ray ray = Camera.main.ScreenPointToRay(realtarpo);
			float hitDist = 0.0f;
			
			if (playerPlane.Raycast(ray, out hitDist))
			{
				var targetPoint = ray.GetPoint(hitDist);
				targetPosition = targetPoint;
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				transform.rotation = targetRotation;
			}
		}
		
		Vector3 direction = targetPosition - transform.position;
		float distance = direction.magnitude;
		float step = speed * Time.deltaTime;
		
		//as long as object is away from target destination...
		if (distance > step)
		{
			//...move toward direction of target position at specified speed
			transform.position += direction.normalized * step;
		}
		else //...otherwise...
		{
			//...keep object at target position
			transform.position = targetPosition;
		}
	}
}