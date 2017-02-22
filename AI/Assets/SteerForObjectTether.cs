using System.Collections;
using UnitySteer.Behaviors;
using System.Collections.Generic;
using UnityEngine;

public class SteerForObjectTether : SteerForTether {

	public GameObject target;

	void Start(){
		target = GameObject.Find("Capsule");
	}
	// Update is called once per frame
	void Update () {
		
		TetherPosition = target.transform.position;
	}
}
