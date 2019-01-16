using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static int gameStage = 0;
	
	public static Color red = Color.red;
	public static Color green = Color.green;

	[SerializeField] public Button _button1;
	[SerializeField] public Button _button2;
	[SerializeField] public Button _button3;
	[SerializeField] public Button _button4;
	[SerializeField] public Button _button5;
	[SerializeField] public Button _button6;

	[SerializeField] public GameObject replay;

	[SerializeField] Text moneyText;
	[SerializeField] Text costToHire;
	[SerializeField] private Text noOfAstronauts;
	[SerializeField] private Text alertText;
	[SerializeField] private Image alertColor;

	private int profit = State.money - 5000000;
	
	private void Start()
	{
		State.noOfAstronauts = 1;
		noOfAstronauts.text = State.noOfAstronauts.ToString();
		costToHire.text = "Cost: " + State.costToHire.ToString() + "$";

		red.a = 0;
		alertColor.color = red;
		
		if (gameStage == 6)
		{
			
			red.a = 0;
			green.a = 1;
			alertColor.color = green;
			alertText.text = "Game over. You made a total of " + profit.ToString() + "$ Profit.";
		}

	}

	void Update()
	{
		CheckGameStage();
		
		if (State.playerDidWin)
		{
			green.a = 1;
			alertColor.color = green;
			alertText.color = Color.black;
			alertText.text = "You made " + State.returnCost.ToString() + "$.";
		} 
		else if (!State.playerDidWin && gameStage != 0)
		{
			red.a = 1;
			alertColor.color = red;
			alertText.color = Color.white;
			alertText.text = "You lost " + State.investmentCost.ToString() + "$.";
		}
		else if (State.noOfAstronauts > 0)
		{
			alertText.text = "";
			red.a = 0;
			alertText.color = Color.white;
			alertColor.color = red;
		}
		
		if (State.money - 1 * State.costToHire < 0)
		{
			alertText.text = "Game over. You made a total of " + profit.ToString() + "$ Profit.";
			red.a = 1;
			alertText.color = Color.white;

			alertColor.color = red;
		}
		else if (State.money - State.noOfAstronauts * State.costToHire < 0)
		{
			alertText.color = Color.white;
			alertText.text = "Not enough money to hire " + State.noOfAstronauts + " astronauts.";
			red.a = 1;
			alertColor.color = red;
		} 
		
		if (gameStage == 6)
		{
			int profit = State.money - 5000000;
			green.a = 1;
			alertColor.color = green;
			alertText.color = Color.black;
			alertText.text = "You have made " + profit.ToString() + "$ Profit.";
		}

		noOfAstronauts.text = State.noOfAstronauts.ToString();
		moneyText.text = "$" + State.money.ToString();
		costToHire.text = "Cost: " + (State.costToHire * State.noOfAstronauts).ToString() + "$";
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
