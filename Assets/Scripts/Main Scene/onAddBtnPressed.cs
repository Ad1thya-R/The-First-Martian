using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAddBtnPressed : MonoBehaviour {
    
    public void Button_Click()
    {
        State.noOfAstronauts++;
        print(State.noOfAstronauts);
    }
}
