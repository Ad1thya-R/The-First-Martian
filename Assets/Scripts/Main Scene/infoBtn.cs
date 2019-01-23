using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoBtn : MonoBehaviour
{

	[SerializeField] private Text instructions; 
	
	public void InfoBtnClicked()
	{
		if (!State.peekAtInstructions)
		{
			instructions.text =
				"markwatney$ Establishing connection to Earth... \nmarkwatney$ Hi! I’m Matt. \nmarkwatney$ I am first human to have set foot on Mars.\nmarkwatney$ I run a company back on earth called 'The First Martian Inc.' \nmarkwatney$ As you can probably see, we find ourselves on Mars. \nmarkwatney$ Over the past few years, companies like mine have worked tirelessly to help expand the space industry. \nmarkwatney$ Space seems very profitable, if cared for through great leadership and management. \nmarkwatney$ That’s where we need your help. \nmarkwatney$ By hiring astronauts and controlling the rocket to land safely, you can help the company make great profits! \nmarkwatney$ While doing this, our company can urbanise the planet of mars. \nmarkwatney$ But completing this task successfully will not be easy. \nmarkwatney$ You will face various obstacles, such as Martian rocks and fuel shortages. \nmarkwatney$ The goal of each level is to safely transport the rocket from one launchpad to another. \nmarkwatney$ If you decide to use many astronauts, you will produce larger profits. \nmarkwatney$ Be cautious as you progress, however, as losing too many astronauts can lead to failure. \nmarkwatney$ The rocket is controlled using the keys W or Spacebar for upward thrust as well as A and D for tilting it left and right respectively. \nmarkwatney$ Good luck on your mission, fellow Martian!";
			State.peekAtInstructions = true;
		}
		else if (State.peekAtInstructions)
		{
			instructions.text = "";
			State.peekAtInstructions = false;
		}
	}
}
