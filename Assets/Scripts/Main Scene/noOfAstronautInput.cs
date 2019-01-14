using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noOfAstronautInput : MonoBehaviour
{

	public InputField _noOfAstronauts;

	// Update is called once per frame
	void Update ()
	{
		_noOfAstronauts.onEndEdit.AddListener(NoOfAstronautsChanged);
	}

	void NoOfAstronautsChanged(string arg0)
	{
		State.noOfAstronauts = Int32.Parse(arg0);
		print(State.noOfAstronauts);
	}
	
}
