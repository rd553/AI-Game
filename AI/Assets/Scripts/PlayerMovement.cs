using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Weapon weapon;
	public float jumpSpeed;
	//public float minJumpHeight;
	//public float maxJumpHeight;
	public float fallSpeed;
	public float maxFallSpeed;

	private CharacterController controller;
	private bool jumping;
	private float jumpHeight;

	// Use this for initialization
	void Start () {
		jumping = false;
		jumpHeight = 0f;
		controller = gameObject.GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			controller.SimpleMove (transform.forward * speed);
		} else if (Input.GetKey (KeyCode.S)) {
			controller.SimpleMove (-transform.forward * speed);
		}

		if (Input.GetKey (KeyCode.A)) {
			controller.SimpleMove (-transform.right * speed);
		} else if (Input.GetKey (KeyCode.D)) {
			controller.SimpleMove (transform.right * speed);
		}



		if (Input.GetKeyDown (KeyCode.Space) && controller.isGrounded) {
			StartCoroutine (Jump ());
		}

		if (!controller.isGrounded) {
			
		}

		/**if (Input.GetKeyDown (KeyCode.Space) && controller.isGrounded) {
			jumping = true;
			controller.Move (transform.up * jumpSpeed);

		} else if ((Input.GetKey (KeyCode.Space) && jumping && !controller.isGrounded && jumpHeight<maxJumpHeight)
			|| (jumpHeight < minJumpHeight)) {
			Vector3 jump = transform.up * jumpSpeed;
			controller.Move (jump);
			jumpHeight += jump.y;
		} else if(jumping){
			jumping = false;
			jumpHeight = 0f;
		}
		 
		if (!jumping && !controller.isGrounded){
				controller.Move(-transform.up*fallSpeed);
			}
			//JUMP
			//and some isGrounded stuff too probably who knows*/




		if(Input.GetMouseButtonDown(0) ||
			(weapon.automatic && Input.GetMouseButton(0)))
			{
				Fire();}

	}

	IEnumerator Jump(){

		Vector3 jumpForce = transform.up * jumpSpeed;
		controller.Move (jumpForce);

		while (!controller.isGrounded) {
			jumpForce -= new Vector3(0,fallSpeed,0);
			jumpForce.y = Mathf.Max (jumpForce.y, -maxFallSpeed);
			controller.Move (jumpForce);
			yield return null;
		}






	}

	private void Fire(){
		weapon.GetComponent<Weapon>().Fire ();
	}

	public void GainAmmo(int amount){
		weapon.GainAmmo (amount);
	}
}
