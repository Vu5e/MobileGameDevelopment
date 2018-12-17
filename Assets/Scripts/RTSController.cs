using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RTSController : MonoBehaviour 
{

	Rect rect = new Rect();

	Vector3 startPos;
	Vector3 endPos;

	public Texture texture;

	public List<Transform> units = new List<Transform>();

	public MoveUnitScript moveUnit;

	void Start()
	{
		SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_PLAY);
	}

	void Update () 
	{
		// OnInputDown
		if(Input.GetMouseButtonDown(0))
		{
			rect = new Rect();

			startPos = Input.mousePosition;
			endPos = Vector3.zero;

			units = new List<Transform>();
		}

		// OnInputDrag
		if(Input.GetMouseButton(0))
		{
			endPos = Input.mousePosition;

			Vector3 size = endPos - startPos;
			rect = new Rect(startPos.x, startPos.y, size.x, size.y);
		}

		// OnInputUp
		if(Input.GetMouseButtonUp(0))
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

			for(int i = 0; i < gos.Length; i++)
			{
				if(rect.Contains(Camera.main.WorldToScreenPoint(gos[i].transform.position), true))
				{
					units.Add(gos[i].transform);
					moveUnit = gos[i].GetComponent<MoveUnitScript>();
					moveUnit.isHighlighted = true;
				}
			}

			rect = new Rect();
		}
	}


	void OnGUI()
	{
		GUI.DrawTexture(new Rect(rect.x, Screen.height - rect.y, rect.width, rect.height * -1f), texture);
	}

	public void ClearList()
	{
		if(units.Count > 0)
		{
			moveUnit.isHighlighted = false;
			units.Clear();
		}
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(0);
	}
}
