using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	public static int instructionIndex = 0;

	[SerializeField] GameObject instructionsGO;
	[SerializeField] private Text instructions;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		instructions.text = "Establishing connection to Earth...";

		if (!IsInvoking("IncreaseInstructionIndex"))
		{
			InvokeRepeating("IncreaseInstructionIndex", 2f, 3f);
		}
		
		instructions.text = State.instructions[instructionIndex];

		if (Input.GetKey(KeyCode.Return) && !State.instructionsArePlaying)
		{
			SceneManager.LoadScene(2);
		}
	}

	
	void IncreaseInstructionIndex()
	{
		
		if (instructionIndex != 17 && !skipBtnPressed.skipButtonHasBeenPressed)
		{
			State.instructionsArePlaying = true;
			instructionIndex++;
		}
		else 
		{
			State.instructionsArePlaying = false;
		}

		if (instructionIndex == 16)
		{
			State.instructionsArePlaying = false;
		}
	}
	
}
