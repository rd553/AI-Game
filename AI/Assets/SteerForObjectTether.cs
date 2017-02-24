using System.Collections;
using UnitySteer.Behaviors;
using System.Collections.Generic;
using UnityEngine;

public class SteerForObjectTether : SteerForTether, BTSteering {

	public string targetName;
	public bool timeout;
	public float timeouttime;

	protected GameObject target;

	void Start(){
		target = GameObject.Find(targetName);
	}
	// Update is called once per frame
	void Update () {
		
		TetherPosition = target.transform.position;
		if (timeout) {
			timeouttime -= Time.deltaTime;
		}
	}

	public virtual bool? GetSuccess(){
		bool? r;

		if (timeout && timeouttime <= 0) {
			r = false;
		} else {
			Vector3 p = gameObject.transform.position;
			Vector3 t = TetherPosition;


			r = (Mathf.Sqrt ((Mathf.Pow ((p.x - t.x), 2)) + (Mathf.Pow ((p.z - t.z), 2))) <= MaximumDistance) ? (bool?)true : (bool?)null;
		}
		return r;
	}
}
