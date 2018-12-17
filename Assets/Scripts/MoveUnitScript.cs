using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveUnitScript : MonoBehaviour 
{

	public bool isHighlighted;

	Vector3 targetPosition = Vector3.zero;
	bool isMouseMode = true;
	public float speed = 50.0f;
	Vector3 offset;

	NavMeshAgent navMeshAgent;

	void Start () 
	{
		isHighlighted = false;

		navMeshAgent = GetComponent<NavMeshAgent>();
		StartCoroutine(RepathRoutine());

//		Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f, Screen.height/2f));
//		RaycastHit hit;
//
//		if(Physics.Raycast(ray, out hit, 10000f))
//		{
//			offset = this.transform.position - hit.point;
//		}
	}


	IEnumerator RepathRoutine()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);

			if(isHighlighted == true)
			{
				navMeshAgent.SetDestination(targetPosition + offset);
			}
		}
	}


	void Update () 
	{
		if (isMouseMode == true) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				// Mouse Simulations
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit, 10000f))
				{
					SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_MOVED);
					targetPosition = hit.point;
				}
			}
		}
		else
		{
			//Touch Controls
			if (Input.touchCount > 0) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit, 10000f))
				{
					SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_MOVED);
					targetPosition = hit.point;
				}
			}
		}
	}
}
