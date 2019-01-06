using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumeBtnPressed : MonoBehaviour
{

	[SerializeField] private GameObject pausePanel;
	[SerializeField] private Button resumeBtn;
	
	// Use this for initialization
	void Start () {
		resumeBtn.onClick.AddListener(ResumeBtnPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResumeBtnPressed()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
}
