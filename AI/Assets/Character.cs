using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public int maxHealth;
	public int currentHealth{ get; protected set; }

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	protected void Initialize(){
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
