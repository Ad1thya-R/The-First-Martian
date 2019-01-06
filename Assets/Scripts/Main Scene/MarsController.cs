using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsController : MonoBehaviour {

    [SerializeField] float speed = 1f;
	
	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0f, -0.02f, 0f);
		if (Input.GetMouseButton(0))
		{
			transform.Rotate(new Vector3(0f, -Input.GetAxis("Mouse X"), 0) * Time.deltaTime *
			                 speed);

		}
	}
	
}
