using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public UnityEngine.UI.Text hpText;
	public UnityEngine.UI.Text deadText;
	private bool dead;

	// Use this for initialization
	void Start () {
		base.Initialize ();
		updateUI ();
		dead = false;
		deadText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dead && Input.GetKeyDown (KeyCode.Space)) {
			Application.Quit ();
		}
	}

	void OnTriggerEnter(Collider c){



		EnemyShot b = c.gameObject.GetComponent<EnemyShot> ();


		if(b!=null){
			currentHealth -= b.damage;
			updateUI();
			if (currentHealth <= 0) {

				Die ();


			}




		}

		if (c.gameObject.layer == 13) {
			Die ();
		}
	}

	void Die(){
		currentHealth = 0;
		Destroy(gameObject.GetComponent<PlayerMovement> ());
		updateUI ();
		dead = true;
		deadText.enabled = true;
	}

	void updateUI(){
		hpText.text = ""+currentHealth;
	}
}
