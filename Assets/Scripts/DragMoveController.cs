using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMoveController : MonoBehaviour {

	bool useMouse = true;
	public Vector3 direction;
	public Vector3 lastMousePos;
	public float baseSpeed = 10f;
	private float magnitude;

	void Start () 
	{
		lastMousePos = Input.mousePosition;
		useMouse = false;
	}


	void Update () 
	{
		if (useMouse == true) 
		{
			MouseDrag ();
		}
		else
		{
			TouchDrag();	
		}
	}


	void MouseDrag()
	{
		if(Input.GetMouseButtonDown(0))
		{
			direction = (Input.mousePosition - lastMousePos).normalized;
			magnitude = (Input.mousePosition - lastMousePos).magnitude;
		}
		else
		{
			direction = Vector3.MoveTowards(direction, Vector3.zero, Time.deltaTime);
		}


		lastMousePos = Input.mousePosition;
	}


	void TouchDrag()
	{
		if (Input.touchCount > 0) 
		{
			direction = Input.touches[0].deltaPosition.normalized;
		}
		else
		{
			direction = Vector3.MoveTowards(direction, Vector3.zero, Time.deltaTime);
		}
	}


	void LateUpdate()
	{
		Vector3 worldDir = new Vector3(direction.x, 0, direction.y); // Convert XY to XZ
		this.transform.Translate(-worldDir * Time.deltaTime * baseSpeed * magnitude, Space.World);
	}
}
