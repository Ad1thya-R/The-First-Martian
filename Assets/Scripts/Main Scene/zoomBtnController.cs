using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoomBtnController : MonoBehaviour
{

	[SerializeField] private Button zoomBtn;
	[SerializeField] private Camera mainCamera;

	[SerializeField] private Sprite _zoomInBtn;
	[SerializeField] private Sprite _zoomOutBtn;
	
	[SerializeField] private GameObject _play;

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
	
	public static bool isZoomedIn;
	
	// Use this for initialization
	void Start ()
	{
		isZoomedIn = false;
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
			_play.SetActive(false);
			_level1.SetActive(false);
			_level2.SetActive(false);
			_level3.SetActive(false);
			_level4.SetActive(false);
			_level5.SetActive(false);
			_level6.SetActive(false);
			_replay.SetActive(false);
			zoomBtn.image.overrideSprite = _zoomOutBtn;
			isZoomedIn = true;
		}
		else
		{
			mainCamera.transform.position = new Vector3(0f, -1.52473f, -4.798908f);

			if (GameController.gameStage < 1)
			{
				_play.SetActive(true);
			}
			else if (GameController.gameStage == 6)
			{
				_replay.SetActive(true);
				_level1.SetActive(true);
				_level2.SetActive(true);
				_level3.SetActive(true);
				_level4.SetActive(true);
				_level5.SetActive(true);
				_level6.SetActive(true);
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
			}
			
			zoomBtn.image.overrideSprite = _zoomInBtn;
			isZoomedIn = false;
		}

	}
}
