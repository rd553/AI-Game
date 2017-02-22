using System.Collections;
using UnitySteer.Behaviors;
using System.Collections.Generic;
using UnityEngine;

public class SteerForObjectTether : SteerForTether {

	public string targetName;
	private GameObject target;

	void Start(){
		target = GameObject.Find(targetName);
	}
	// Update is called once per frame
	void Update () {
		
		TetherPosition = target.transform.position;
	}
}
