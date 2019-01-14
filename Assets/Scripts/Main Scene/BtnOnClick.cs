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


	// Use this for initialization
	void Start ()
	{
		btn.onClick.AddListener(BtnClicked);
	}

	void BtnClicked()
	{
		if (State.noOfAstronauts != 0)
		{
			
			if (State.money - State.noOfAstronauts * State.costToHire > 0)
			{
				State.money = State.money - State.noOfAstronauts * State.costToHire;
				SceneManager.LoadScene(Int32.Parse(indexOfLvlToLoad));
			}
			else if (State.money - State.noOfAstronauts * State.costToHire < 0)
			{
				alertText.text = "Not enough money to hire " + State.noOfAstronauts + " astronauts.";
			} 
			
		}
		else
		{
			alertText.text = "You have to at least hire one astronaut";
		}
	}
}
