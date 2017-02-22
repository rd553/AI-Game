using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {


	public GameObject aperture;
	private GameObject player;

	private Color normalColor;
	private Color flashColor = Color.red;
	private bool flash;

	private float flashTimeLeft;

	public float flashTime;

	void Start () {
		base.Initialize ();
		player = GameObject.Find ("Capsule");
		flash = false;
		flashTimeLeft = 0;
		normalColor = gameObject.GetComponent<Renderer> ().material.color;

		StartCoroutine (Behave ());
	}
	
	// Update is called once per frame
	void Update () {
		if (flash) {
			flashTimeLeft -= Time.deltaTime;
			if (flashTimeLeft <= 0) {
				gameObject.GetComponent<Renderer> ().material.color = normalColor;
				flash = false;
			}
		}


		
	}

	IEnumerator Behave(){
		while (true) {
			Ray ray = new Ray (gameObject.transform.position, player.transform.position - gameObject.transform.position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) &&
			   hit.transform.gameObject.layer == 8) {
				GameObject shot = GameObject.Instantiate (Resources.Load ("EnemyShot")) as GameObject;
				shot.transform.position = aperture.transform.position;
				shot.transform.LookAt (player.transform);

				shot.GetComponent<Rigidbody> ().AddForce (shot.transform.forward * 15f, ForceMode.Impulse);
				yield return new WaitForSeconds (1.0f);
			}
			yield return null;

		}
	}

	void FireAtPlayer(){

	}
		

	void OnCollisionEnter(Collision c){

		Bullet b = c.gameObject.GetComponent<Bullet> ();


		if(b!=null){
			currentHealth -= b.damage;
			if (currentHealth <= 0) {
				BeDestroyed ();
			}
			GameObject number = GameObject.Instantiate (Resources.Load ("DamageNum")) as GameObject;
			number.transform.position = c.transform.position;
			Vector3 rot = c.transform.rotation.eulerAngles;
			number.transform.rotation = Quaternion.Euler(new Vector3 (0, rot.y, 0));
			number.GetComponent<TextMesh> ().text = ""+b.damage;

			gameObject.GetComponent<Renderer> ().material.color = flashColor;
			flashTimeLeft = flashTime;
			flash = true;


}
	}

	void FireAtTarget(GameObject target){

	}

	void BeDestroyed(){
		Destroy (gameObject);
	}

}
