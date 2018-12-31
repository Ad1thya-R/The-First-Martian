using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtnPressed : MonoBehaviour
{

	[SerializeField]  Button PlayBtn;
	[SerializeField]  GameObject PlayBtnGameObject;

	[SerializeField]  GameObject _button1;
	[SerializeField]  GameObject _button2;
	[SerializeField]  GameObject _button3;
	[SerializeField]  GameObject _button4;
	[SerializeField]  GameObject _button5;
	[SerializeField]  GameObject _button6;
	
	// Use this for initialization
	void Start () {
		_button1.SetActive(false);
		_button2.SetActive(false);
		_button3.SetActive(false);
		_button4.SetActive(false);
		_button5.SetActive(false);
		_button6.SetActive(false);
		
		PlayBtn.onClick.AddListener(PlayBtnClicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayBtnClicked()
	{
		PlayBtnGameObject.SetActive(false);
		
		Invoke("setBtn1active", 0.1f);
		Invoke("setBtn2active", 0.14f);
		Invoke("setBtn3active", 0.2f);
		Invoke("setBtn4active", 0.25f);
		Invoke("setBtn5active", 0.3f);
		Invoke("setBtn6active", 0.35f);

	}

	void setBtn1active()
	{
		_button1.SetActive(true);
	}
	void setBtn2active()
	{
		_button2.SetActive(true);
	}
	void setBtn3active()
	{
		_button3.SetActive(true);
	}
	void setBtn4active()
	{
		_button4.SetActive(true);
	}
	void setBtn5active()
	{
		_button5.SetActive(true);
	}
	void setBtn6active()
	{
		_button6.SetActive(true);
	}
}
