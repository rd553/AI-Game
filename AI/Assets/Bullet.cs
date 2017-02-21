using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float timeToLive;
	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeToLive -= Time.deltaTime;
		if (timeToLive <= 0)
			Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col){
		Destroy (gameObject);

	}
}
