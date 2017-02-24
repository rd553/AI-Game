using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BTNode {


	public Decorator(BTNode child) : base(){
		children.Add (child);
		child.parent = this;
	}


	
	public override bool? GetSuccess ()
	{
		return children [0].GetSuccess ();
	}
}
