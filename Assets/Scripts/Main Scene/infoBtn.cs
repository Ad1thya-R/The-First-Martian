using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class infoBtn : MonoBehaviour
{

	[SerializeField] private Text instructions; 
	
	public void InfoBtnClicked()
	{
		if (!Replay.replayQuery)
		{
			State.disableSkip = true;
			SceneManager.LoadScene(1);
		}	
	}
}
