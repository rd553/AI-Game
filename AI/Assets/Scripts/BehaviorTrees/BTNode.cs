using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;

public abstract class BTNode  {

	protected bool? succeeded;

	public BTNode parent;

	protected List<BTNode> children;

	public BTNode(){
		children = new List<BTNode> ();
	}

	public abstract bool? GetSuccess();

	public virtual void Reset(){
		succeeded = null;
		foreach (BTNode child in children) {
			child.Reset ();
		}
	}

	public virtual BTNode GetRoot(){
		return(parent.GetRoot ());

}

	public virtual void OnReturn(bool? r){
		succeeded = r;
	}

}
