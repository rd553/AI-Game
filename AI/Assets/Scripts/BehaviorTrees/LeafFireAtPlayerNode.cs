using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFireAtPlayerNode : LeafNode {

	private GameObject player;
	private float timebetween;
	private float timesofar;

	public LeafFireAtPlayerNode(string targetname, float p){
		player = GameObject.Find (targetname);
		timebetween = p;
		timesofar = 0f;
	}

	public override bool? GetSuccess (){
		RootNode root = (RootNode)GetRoot ();
		GameObject aperture = root.tree.gameObject.transform.Find ("Aperture").gameObject;

		if (timesofar >= timebetween) {
			GameObject shot = GameObject.Instantiate (Resources.Load ("EnemyShot")) as GameObject;
			shot.transform.position = aperture.transform.position;
			shot.transform.LookAt (player.transform);

			shot.GetComponent<Rigidbody> ().AddForce (shot.transform.forward * 15f, ForceMode.Impulse);
			timesofar = 0f;
		} 

		else {
			timesofar += Time.deltaTime;
		}

		return true;
	}
}
