using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backBtnPressed : MonoBehaviour
{

	[SerializeField] private Button backBtn;
	
	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener(BackBtnPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackBtnPressed()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
