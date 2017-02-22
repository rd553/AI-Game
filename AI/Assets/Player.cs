using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public UnityEngine.UI.Text hpText;

	// Use this for initialization
	void Start () {
		base.Initialize ();
		updateUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){

		EnemyShot b = c.gameObject.GetComponent<EnemyShot> ();


		if(b!=null){
			currentHealth -= b.damage;
			updateUI();
			/**if (currentHealth <= 0) {
				BeDestroyed ();
			}*/




		}
	}

	void updateUI(){
		hpText.text = ""+currentHealth;
	}
}
