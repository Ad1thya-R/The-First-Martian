using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skipBtnPressed : MonoBehaviour
{
	[SerializeField] Button skipButton;
	[SerializeField] private GameObject skipButtonGO;

	[SerializeField] private Text instructions;
	[SerializeField] private GameObject instructionsGO;

	public static bool skipButtonHasBeenPressed = false;
	
	// Use this for initialization
	void Start () {
		if (State.disableSkip)
		{
			skipButtonGO.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!State.instructionsArePlaying)
		{
			skipButtonGO.SetActive(false);
		}
		
		skipButton.onClick.AddListener(SkipBtnPressed);
	}

	void SkipBtnPressed()
	{
		skipButtonHasBeenPressed = true;
		skipButtonGO.SetActive(false);
		State.instructionsArePlaying = false;
		instructions.text =
			State.line1 + State.line2 + State.line3 + State.line4 + State.line5 + State.line6 + State.line7 + State.line8 + State.line9 + State.line10 + State.line11 + State.line12 + State.line13;
		TextController.instructionIndex = State.instructions.Length - 1;
	}
}
