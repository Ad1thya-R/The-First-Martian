using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

	[SerializeField] private GameObject fallingObstacle;
	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start ()
	{
		_rigidbody = fallingObstacle.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		_rigidbody.isKinematic = false;		
	}
}
