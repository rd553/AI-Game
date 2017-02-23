using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : BTNode {

	public BehaviourTree tree;

	public RootNode(BTNode child) : base(){
		children.Add (child);
		parent = null;
		child.parent = this;
	}

	public override BTNode GetRoot ()
	{
		return this;
	}

	public override bool? GetSuccess ()
	{
		return children [0].GetSuccess ();
	}
}
