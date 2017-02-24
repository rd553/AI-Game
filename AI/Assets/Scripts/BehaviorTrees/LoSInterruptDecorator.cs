using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoSInterruptDecorator : Decorator {

	private GameObject player;
	private float distance;
	private float timeout;
	private float maxtimeout;

	public LoSInterruptDecorator(BTNode child, string name, float d, float t) : base(child){
		player = GameObject.Find (name);
		distance = d;
		maxtimeout = t;
		timeout = 0;
	}

	public override bool? GetSuccess ()
	{

		if (succeeded != null) {
			return succeeded;
		}
		Debug.Log ("Running!");
		RootNode root = (RootNode)GetRoot ();
		GameObject go = root.tree.gameObject;
		bool? s = children [0].GetSuccess ();

		Ray ray = new Ray (go.transform.position, player.transform.position - go.transform.position);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit) &&
		    hit.transform.gameObject.layer == 8) {
			timeout = 0;
			Debug.Log ("I see you...");
			succeeded = s;
			children [0].OnReturn (s);
			return s;
		} 

		else {
			Debug.Log ("Can't see you!");
			timeout += Time.deltaTime;

			if (timeout >= maxtimeout) 
			{
				Debug.Log ("Stop!");
				succeeded = false;
				children [0].OnReturn (false);
				return false;
			} 
			else {
				succeeded = s; children [0].OnReturn (s); return s;}
		}


	}

	public override void Reset(){
		base.Reset ();
		timeout = 0;
	}
}
