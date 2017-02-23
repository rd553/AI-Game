using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class SteerForFlank : SteerForObjectTether {

	GameObject flanktarget;


	void Start(){

		target = GameObject.Find(targetName);
		flanktarget = new GameObject ();

		Vector3 origin = gameObject.transform.position;
		Vector3 tar = target.transform.position;
		tar.y = origin.y;


		Vector3 dirToTarget = tar - origin;
		Vector3 per = Vector3.Cross (dirToTarget, Vector3.up);

		Ray ray = new Ray(origin, per);
		//Debug.DrawRay (origin, dirToTarget,Color.red,200f);
		//Debug.DrawRay (tar, per, Color.green, 200f);
		RaycastHit hit;
		Vector3 hitloc;
		if(Physics.Raycast (ray, out hit,10f,1<<1)){
			hitloc = hit.transform.position;

		}
		else{
			hitloc = -per.normalized * 10f - tar;
		}

		Vector3 tohit = tar - hitloc;
		tohit /= 2;
		flanktarget.transform.position = tohit;

			
	}

	void Update(){
		TetherPosition = flanktarget.transform.position;
		if (timeout) {
			timeouttime -= Time.deltaTime;
		}
	}




}
