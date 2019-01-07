using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static int gameStage = 0;

	[SerializeField] public Button _button1;
	[SerializeField] public Button _button2;
	[SerializeField] public Button _button3;
	[SerializeField] public Button _button4;
	[SerializeField] public Button _button5;
	[SerializeField] public Button _button6;

	[SerializeField] public GameObject replay;

	private void Start()
	{
		gameStage = PlayerPrefs.GetInt("gameStageSavedInPlayerPrefs");
	}

	void Update()
	{
		CheckGameStage();
	}

	void CheckGameStage()
	{
		switch (gameStage)
		{
			case 0:

				Activate(
					true,
					false,
					false,
					false,
					false,
					false,
					true
				);

				break;

			case 1:

				Activate(
					false,
					true,
					false,
					false,
					false,
					false,
					true
				);

				break;

			case 2:

				Activate(
					false,
					false,
					true,
					false,
					false,
					false,
					true
				);

				break;

			case 3:

				Activate(
					false,
					false,
					false,
					true,
					false,
					false,
					true
				);

				break;

			case 4:

				Activate(
					false,
					false,
					false,
					false,
					true,
					false,
					true
				);

				break;

			case 5:

				Activate(
					false,
					false,
					false,
					false,
					false,
					true,
					true
				);

				break;

			case 6:

				Activate(
					false,
					false,
					false,
					false,
					false,
					false,
					true
				);

				break;
		}
	}

	private void Activate(bool button1, bool button2, bool button3, bool button4, bool button5, bool button6, bool replayBtn)
	{
		_button1.interactable = button1;
		_button2.interactable = button2;
		_button3.interactable = button3;
		_button4.interactable = button4;
		_button5.interactable = button5;
		_button6.interactable = button6;
		if (!zoomBtnController.isZoomedIn)
		{
			replay.SetActive(replayBtn);
		}
	}
}
