using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;

public class zoomBtnController : MonoBehaviour
{

	[SerializeField] private Button zoomBtn;
	[SerializeField] private Camera mainCamera;

	[SerializeField] private Sprite _zoomInBtn;
	[SerializeField] private Sprite _zoomOutBtn;

	[SerializeField] private GameObject _level1;
	[SerializeField] private GameObject _level2;
	[SerializeField] private GameObject _level3;
	[SerializeField] private GameObject _level4;
	[SerializeField] private GameObject _level5;
	[SerializeField] private GameObject _level6;
	[SerializeField] private GameObject _replay;

	[SerializeField] private Button _button1;
	[SerializeField] private Button _button2;
	[SerializeField] private Button _button3;
	[SerializeField] private Button _button4;
	[SerializeField] private Button _button5;
	[SerializeField] private Button _button6;

	[SerializeField] private GameObject dollar;
	[SerializeField] private GameObject noOfAstronauts;
	[SerializeField] private GameObject noOfAstronautsTextField;
	[SerializeField] private GameObject costToHire;
	[SerializeField] private GameObject infoText;

	[SerializeField] private GameObject decreaseBtn;
	[SerializeField] private GameObject increaseBtn;
	[SerializeField] private GameObject alertColor;
	
	public static bool isZoomedIn;
	
	// Use this for initialization
	void Start ()
	{
		isZoomedIn = false;
		dollar.SetActive(true);
		noOfAstronauts.SetActive(true);
		noOfAstronautsTextField.SetActive(true);
		costToHire.SetActive(true);
		zoomBtn.onClick.AddListener(zoomBtnClicked);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void zoomBtnClicked()
	{
		if (!isZoomedIn)
		{
			mainCamera.transform.position = new Vector3(0f, -1.52473f, 0.84f);
			_level1.SetActive(false);
			_level2.SetActive(false);
			_level3.SetActive(false);
			_level4.SetActive(false);
			_level5.SetActive(false);
			_level6.SetActive(false);
			_replay.SetActive(false);
			alertColor.SetActive(false);
			
			dollar.SetActive(false);
			noOfAstronauts.SetActive(false);
			noOfAstronautsTextField.SetActive(false);
			costToHire.SetActive(false);
			infoText.SetActive(false);
			
			increaseBtn.SetActive(false);
			decreaseBtn.SetActive(false);
			
			zoomBtn.image.overrideSprite = _zoomOutBtn;
			isZoomedIn = true;
		}
		else
		{
			mainCamera.transform.position = new Vector3(0f, -1.52473f, -4.798908f);

			if (GameController.gameStage == 6)
			{
				_replay.SetActive(true);
				_level1.SetActive(true);
				_level2.SetActive(true);
				_level3.SetActive(true);
				_level4.SetActive(true);
				_level5.SetActive(true);
				_level6.SetActive(true);
				dollar.SetActive(true);
				noOfAstronauts.SetActive(true);
				noOfAstronautsTextField.SetActive(true);
				costToHire.SetActive(true);
				infoText.SetActive(true);
				alertColor.SetActive(true);
				
				increaseBtn.SetActive(true);
				decreaseBtn.SetActive(true);		
			}
			else
			{
				_level1.SetActive(true);
				_level2.SetActive(true);
				_level3.SetActive(true);
				_level4.SetActive(true);
				_level5.SetActive(true);
				_level6.SetActive(true);
				_replay.SetActive(false);
				alertColor.SetActive(true);
				
				dollar.SetActive(true);
				noOfAstronauts.SetActive(true);
				noOfAstronautsTextField.SetActive(true);
				costToHire.SetActive(true);
				infoText.SetActive(true);
				
				increaseBtn.SetActive(true);
				decreaseBtn.SetActive(true);
			}
			
			zoomBtn.image.overrideSprite = _zoomInBtn;
			isZoomedIn = false;
		}

	}
}
