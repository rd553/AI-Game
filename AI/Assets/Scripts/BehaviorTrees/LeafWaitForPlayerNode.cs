using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafWaitForPlayerNode : LeafNode {

	private GameObject player;
	private float distance;

	private float timeout;
	private float maxtimeout;

	public LeafWaitForPlayerNode(string name, float d, float t){
		player = GameObject.Find (name);
		distance = d;

		if (maxtimeout > 0f) {
			timeout = t;
			maxtimeout = t;
		}
	}

	public override bool? GetSuccess(){

		if (succeeded != null) {
			return succeeded;}

		RootNode root = (RootNode)GetRoot ();
		GameObject go = root.tree.gameObject;

		Ray ray = new Ray (go.transform.position, player.transform.position - go.transform.position);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit) &&
		    hit.transform.gameObject.layer == 8) {
			succeeded = true;
			return true;
		} else if (maxtimeout > 0f) {
			timeout -= Time.deltaTime;
			if (timeout <= 0f) {
				succeeded = false;
				return false;
			}
		} 
			return null;

	}

	public override void Reset ()
	{
		base.Reset ();
		timeout = maxtimeout;
	}


}
