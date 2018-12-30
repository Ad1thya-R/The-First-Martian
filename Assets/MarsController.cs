using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsController : MonoBehaviour {

    [SerializeField] float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);

        }
    }
}
