using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseBtnClicked : MonoBehaviour
{

	[SerializeField] private GameObject pausePanel;

	[SerializeField] Button pauseBtn;
	
	// Use this for initialization
	void Start () {
		pausePanel.SetActive(false);
		pauseBtn.onClick.AddListener(PauseBtnClicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PauseBtnClicked()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}
}
