using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;
using System.Linq;

public class LeafTetherNode : LeafNode {

	string targetname;
	float maxdistance;
	float weight;

	SteerForObjectTether steer;

	public LeafTetherNode(string targetname, float maxdistance, float weight) : base(){
		this.targetname = targetname;
		this.maxdistance = maxdistance;
		this.weight = weight;
	}

	public override bool? GetSuccess ()
	{
		if (succeeded==true) {
			return true;
		}



		if (!active) {
			active = true;
			RootNode root = (RootNode)GetRoot ();
			GameObject go = root.tree.gameObject;

			steer = go.AddComponent<SteerForObjectTether>();
			steer.targetName = targetname;
			steer.MaximumDistance = maxdistance;
			steer.Weight = weight;





			Vehicle v = go.GetComponent<Biped> ();
			v.RecheckPostprocessors ();




		
		}

		bool? success = steer.GetSuccess ();

		if (success==true) {
			steer.enabled = false;
			UnityEngine.Object.Destroy (steer);
			succeeded = true;
		} else if (success == false) {
			steer.enabled = false;
			UnityEngine.Object.Destroy (steer);
			succeeded = false;
		}
		return success;
	}

	public override void OnReturn(bool? b){
		base.OnReturn (b);
		if (b != null && steer != null) {
			GameObject.Destroy (steer);
		}
	}

}
