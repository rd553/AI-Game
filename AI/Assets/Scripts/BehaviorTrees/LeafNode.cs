using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;

public abstract class LeafNode: BTNode {



	public bool active;

	public LeafNode(){
		active = false;
	}




	public override void Reset ()
	{
		active = false;
		base.Reset();
	}
}
