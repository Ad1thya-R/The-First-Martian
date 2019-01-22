using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
	public static bool replayQuery;
	
	[SerializeField] GameObject firstFirstGenBuilding;
	[SerializeField] GameObject firstSecondGenBuilding;
	[SerializeField] GameObject firstThirdGenBuilding;
    
	[SerializeField] GameObject secondFirstGenBuilding;
	[SerializeField] GameObject secondSecondGenBuilding;
	[SerializeField] GameObject secondThirdGenBuilding;

	[SerializeField] private Button btn;

	[SerializeField] private Image alertColor;
	[SerializeField] private Text alertText;
	
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(BtnClicked);
	}
	
	void BtnClicked()
	{
		replayQuery = true;
		alertColor.color = new Color(0.8f, 0.2f, 0f, 1f);
		alertText.text = "Are you sure you want to restart? y / n";
	}

	private void Update()
	{
		if (replayQuery && Input.GetKey(KeyCode.Y))
		{
			replayQuery = false;
			GameController.gameStage = 0;
		
			firstFirstGenBuilding.SetActive(false);
			firstSecondGenBuilding.SetActive(false);
			firstThirdGenBuilding.SetActive(false);
		
			secondFirstGenBuilding.SetActive(false);
			secondSecondGenBuilding.SetActive(false);
			secondThirdGenBuilding.SetActive(false);
			
			BuildingController.upgradeParticles1Gen1Played = false;
			BuildingController.upgradeParticles1Gen2Played = false;
			BuildingController.upgradeParticles1Gen3Played = false;
		
			BuildingController.upgradeParticles2Gen1Played = false;
			BuildingController.upgradeParticles2Gen2Played = false;
			BuildingController.upgradeParticles2Gen3Played = false;

			State.money = 5000000;
			State.costToHire = 700000;

			State.showHowMuchMoneyPlayerMade = false;
			State.noOfAstronauts = 1;
			alertText.text = "";
			GameController.red.a = 0;
			GameController.green.a = 0;
			alertColor.color = GameController.red;
			State.playerDidWin = false;
		} 
		else if (replayQuery && Input.GetKey(KeyCode.N))
		{
			replayQuery = false;
			return;
		}
	}
}
