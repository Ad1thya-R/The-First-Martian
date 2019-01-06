using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryButtonPressed : MonoBehaviour
{

	[SerializeField] private Button retryBtn;
	[SerializeField] private GameObject pausePanel;
	
	// Use this for initialization
	void Start () {
		retryBtn.onClick.AddListener(RetryBtnPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RetryBtnPressed()
	{
		Time.timeScale = 1;
		pausePanel.gameObject.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
