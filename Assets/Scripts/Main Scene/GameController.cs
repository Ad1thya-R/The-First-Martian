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
	private int lostMoney = (State.money - 5000000) * -1;
	
	private void Start()
	{
		State.noOfAstronauts = 1;
		noOfAstronauts.text = State.noOfAstronauts.ToString();
		costToHire.text = "Cost: " + State.costToHire.ToString() + "$";

		red.a = 0;
		alertColor.color = red;

	}

	void Update()
	{
		CheckGameStage();
		
		if (State.money - State.noOfAstronauts * State.costToHire < 0 && State.costToHire < State.money)
		{
			alertText.color = Color.black;
			alertText.text = "Not enough money to hire " + State.noOfAstronauts + " astronauts.";
			alertColor.color = Color.yellow;
		} 
		else if (State.showHowMuchMoneyPlayerMade && gameStage == 6)
		{
			if (State.money > 5000000)
			{
				green.a = 1;
				alertColor.color = green;
				alertText.color = Color.black;
				alertText.text = "Game over. Your company made " + profit.ToString() + "$ profit. (max: 36300000$)";
			}
			else if (State.money < 5000000)
			{
				red.a = 1;
				alertColor.color = red;
				alertText.color = Color.white;
				alertText.text = "Game over. Your company lost " + lostMoney.ToString() + "$.";
			}
			
		}
		else if (State.showHowMuchMoneyPlayerMade && State.costToHire > State.money)
		{
			red.a = 1;
			alertColor.color = red;
			alertText.color = Color.white;
			alertText.text = "Game over. Your company lost " + lostMoney.ToString() + "$.";
			
		}
		else if (State.showHowMuchMoneyPlayerMade)
		{
			if (State.playerDidWin)
			{
				green.a = 1;
				alertColor.color = green;
				alertText.color = Color.black;
				alertText.text = "+" + State.returnCost.ToString() + "$";
			} else if (!State.playerDidWin)
			{
				red.a = 1;
				alertColor.color = red;
				alertText.color = Color.white;
				alertText.text = "-" + State.investmentCost.ToString() + "$";
			}
		}
		else
		{
			red.a = 0;
			alertColor.color = red;
			alertText.text = "";
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
