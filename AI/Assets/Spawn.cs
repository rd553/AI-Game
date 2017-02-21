using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


	// Use this for initialization
	void Start () {

		string prefab = "";

		float r = Random.Range (0f, 1f);

		if (r <= 0.33f) {
			prefab = "Enemy";
		} 
		else if (r <= 0.66f) {
			prefab = "AmmoPickup";
		}

		else{}
	
		if (prefab != "") {
			GameObject go = GameObject.Instantiate (Resources.Load (prefab)) as GameObject;
			go.transform.position = new Vector3(gameObject.transform.position.x, go.transform.position.y, gameObject.transform.position.z);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
