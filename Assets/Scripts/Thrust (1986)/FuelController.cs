using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
	[SerializeField] GameObject _gameObject;
	private Rigidbody _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.isKinematic = false;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0f, -1f, 0f);
	}

	private void OnCollisionEnter(Collision other)
	{
		_gameObject.SetActive(false);	
	}
}
