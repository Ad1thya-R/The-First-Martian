using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBtnPressed : MonoBehaviour {

		[SerializeField] private Button infoBtn;
    	
    	// Use this for initialization
    	void Start () {
    		infoBtn.onClick.AddListener(infoBtnPressed);
    	}
    
    	void infoBtnPressed()
    	{
    		Application.OpenURL("https://github.com/liang-leon/TerraformingMars/blob/master/README.md"); 
    	}
}
