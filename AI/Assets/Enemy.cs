using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	private Color normalColor;
	private Color flashColor = Color.red;
	private bool flash;

	private float flashTimeLeft;

	public float flashTime;

	void Start () {
		base.Initialize ();
		flash = false;
		flashTimeLeft = 0;
		normalColor = gameObject.GetComponent<Renderer> ().material.color;
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

	void BeDestroyed(){
		Destroy (gameObject);
	}

}
