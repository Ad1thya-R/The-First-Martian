using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{

	[SerializeField] private Text _text;
	
	// Use this for initialization
	void Start () {
		_text.transform.SetAsLastSibling();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
