using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<CharacterController> ().SimpleMove (transform.forward * speed);
		} else if (Input.GetKey (KeyCode.S)) {
			gameObject.GetComponent<CharacterController> ().SimpleMove (-transform.forward * speed);
		}

		if (Input.GetKey (KeyCode.A)) {
			gameObject.GetComponent<CharacterController> ().SimpleMove (-transform.right * speed);
		} else if (Input.GetKey (KeyCode.D)) {
			gameObject.GetComponent<CharacterController> ().SimpleMove (transform.right * speed);
		}

	}
}
