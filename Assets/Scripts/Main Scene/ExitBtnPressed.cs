using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtnPressed : MonoBehaviour
{

	[SerializeField] private Button exitBtn;
	
	// Use this for initialization
	void Start () {
		exitBtn.onClick.AddListener(ExitButtonPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ExitButtonPressed()
	{
		Application.Quit();
	}
	
}
