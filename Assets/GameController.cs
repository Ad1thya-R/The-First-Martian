using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static int gameStage = 0;

	[SerializeField] private Button _button1;
	[SerializeField] private Button _button2;
	[SerializeField] private Button _button3;
	[SerializeField] private Button _button4;
	[SerializeField] private Button _button5;
	[SerializeField] private Button _button6;

	[SerializeField] private Button replay;

	// Use this for initialization
	void Start()
	{
	}

	void Update()
	{
		switch (gameStage)
		{
			case 0:
				//print("2, 3, 4, 5, 6 disabled");
				_button1.interactable = true;
				_button2.interactable = false;
				_button3.interactable = false;
				_button4.interactable = false;
				_button5.interactable = false;
				_button6.interactable = false;
				replay.interactable = false;
				break;
			case 1:
				//print("1, 3, 4, 5, 6 disabled");
				_button2.interactable = true;
				_button1.interactable = false;
				_button3.interactable = false;
				_button4.interactable = false;
				_button5.interactable = false;
				_button6.interactable = false;
				replay.interactable = false;

				break;
			case 2:
				//print("1, 2, 4, 5, 6 disabled");
				_button3.interactable = true;
				_button2.interactable = false;
				_button1.interactable = false;
				_button4.interactable = false;
				_button5.interactable = false;
				_button6.interactable = false;
				replay.interactable = false;

				break;
			case 3:
				//print("1, 2, 3, 5, 6 disabled");
				_button4.interactable = true;
				_button2.interactable = false;
				_button3.interactable = false;
				_button1.interactable = false;
				_button5.interactable = false;
				_button6.interactable = false;
				replay.interactable = false;

				break;
			case 4:
				//print("1, 2, 3, 4, 6 disabled");
				_button5.interactable = true;
				_button2.interactable = false;
				_button3.interactable = false;
				_button4.interactable = false;
				_button1.interactable = false;
				_button6.interactable = false;
				replay.interactable = false;

				break;
			case 5:
				//print("1, 2, 3, 4, 5 disabled");
				_button6.interactable = true;
				_button2.interactable = false;
				_button3.interactable = false;
				_button4.interactable = false;
				_button5.interactable = false;
				_button1.interactable = false;
				replay.interactable = false;

				break;
			case 6:

				_button3.interactable = false;
				_button2.interactable = false;
				_button1.interactable = false;
				_button4.interactable = false;
				_button5.interactable = false;
				_button6.interactable = false;
				replay.interactable = true;

				break;

		}
	}
}
