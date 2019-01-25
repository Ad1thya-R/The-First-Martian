using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	private Color hackingGreen;
	
	public static int instructionIndex = 0;

	[SerializeField] GameObject instructionsGO;
	[SerializeField] private Text instructions;

	public static int signalStrength = 0;
	private bool done = false;
	
	// Use this for initialization
	void Start ()
	{
		State.instructionsArePlaying = true;
		
		InvokeRepeating("IncreaseSignalStrength", 2f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		hackingGreen = new Color(0.13f, 0.76f, 0.02f);

		instructions.color = hackingGreen;
		
		instructions.text = "markwatney$ Establishing connection to Earth... \nmarkwatney$ Signal strength: " + signalStrength + "%";

		if (!IsInvoking("IncreaseInstructionIndex") && done)
		{
			State.instructionsArePlaying = true;
			InvokeRepeating("IncreaseInstructionIndex", 0f, 3f);
		}

		if (done)
		{
			instructions.text = State.instructions[instructionIndex];
		}

		if (Input.GetKey(KeyCode.Return) && !State.instructionsArePlaying)
		{
			SceneManager.LoadScene(2);
		}
	}

	void IncreaseSignalStrength()
	{
		System.Random rnd = new System.Random();
		int increaseRate = rnd.Next(0, 4);
		if (signalStrength + increaseRate <= 100)
		{
			signalStrength = signalStrength + increaseRate;
		}
		else
		{
			done = true;
		}
	}

	
	void IncreaseInstructionIndex()
	{
		
		if (instructionIndex != State.instructions.Length - 1 && !skipBtnPressed.skipButtonHasBeenPressed)
		{
			instructionIndex++;
		}
		else 
		{
			State.instructionsArePlaying = false;
		}

		if (instructionIndex == State.instructions.Length - 1)
		{
			State.instructionsArePlaying = false;
		}
	}
	
}
