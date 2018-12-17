using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoinScript : MonoBehaviour 
{
	public float destroyTime = 3.0f;

	public float rotateSpeed = 800.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
	}
}
