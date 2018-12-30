using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
	
	[SerializeField] GameObject firstFirstGenBuilding;
	[SerializeField] GameObject firstSecondGenBuilding;
	[SerializeField] GameObject firstThirdGenBuilding;
    
	[SerializeField] GameObject secondFirstGenBuilding;
	[SerializeField] GameObject secondSecondGenBuilding;
	[SerializeField] GameObject secondThirdGenBuilding;

	[SerializeField] private Button btn;
	
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(BtnClicked);
	}
	
	void BtnClicked()
	{
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

	}
}
