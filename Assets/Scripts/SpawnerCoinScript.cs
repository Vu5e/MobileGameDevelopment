using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoinScript : MonoBehaviour 
{
	public Transform[] spawnPoints;
	public float spawnTime = 2.5f;

	public GameObject coins;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnCoins", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnCoins()
	{
		int spawnIndex = Random.Range(0, spawnPoints.Length); //set the index number

		Instantiate(coins, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
	}
}
