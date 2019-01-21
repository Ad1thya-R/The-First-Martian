using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnClicked : MonoBehaviour
{
	[SerializeField] private Button playBtn;

	// Use this for initialization
	void Start () {
		playBtn.onClick.AddListener(PlayBtnPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayBtnPressed()
	{
		SceneManager.LoadScene(1);
	}
}
