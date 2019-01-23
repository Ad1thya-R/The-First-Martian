using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{

	[SerializeField] Button btn;
	[SerializeField] String indexOfLvlToLoad;

	[SerializeField] private Text alertText;
	[SerializeField] private Image alertColor;


	// Use this for initialization
	void Start ()
	{
		btn.onClick.AddListener(BtnClicked);
	}

	void BtnClicked()
	{
		if (State.noOfAstronauts > 0)
		{
			alertText.text = "";
			GameController.red.a = 0;
			alertColor.color = GameController.red;
			
			
			if (State.money - State.noOfAstronauts * State.costToHire >= 0 && !State.showInstructions)
			{
				SceneManager.LoadScene(Int32.Parse(indexOfLvlToLoad));
			} 
			
		}
		else if(State.noOfAstronauts <= 0)
		{
			GameController.red.a = 0;
			alertColor.color = GameController.red;
			alertText.color = Color.white;
			alertText.text = "You have to at least hire one astronaut!";
		}
	}
}
