using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{

	[SerializeField] Button Btn;
	[SerializeField] String indexOfLvlToLoad;


	// Use this for initialization
	void Start ()
	{
		Btn.onClick.AddListener(BtnClicked);
	}

	void BtnClicked()
	{
		SceneManager.LoadScene(Int32.Parse(indexOfLvlToLoad));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
