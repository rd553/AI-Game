using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : BTNode {



	public SequenceNode(params BTNode[] btns) : base(){
		foreach (BTNode btn in btns) {
			children.Add (btn);
			btn.parent = this;
		}
	}

	public override bool? GetSuccess(){

		if (succeeded != null) {
			return succeeded;
		}

		foreach (BTNode child in children) {
			if (child.GetSuccess () == null) {
				return null;
			} else if (child.GetSuccess() == false) {
				return false;
			}

		}
		return true;
	}
}
