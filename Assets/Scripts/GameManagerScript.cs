using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour 
{
	public int currentCoin;
	public Text coinText;

	public Text endGameText;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentCoin == 50)
		{
			endGameText.text = "GAME END!";
			Time.timeScale = 0.0f;
		}
	}

	public void AddCoin(int coinToAdd)
	{
		currentCoin += coinToAdd;
		coinText.text = "COIN: " + currentCoin;
	}
}
