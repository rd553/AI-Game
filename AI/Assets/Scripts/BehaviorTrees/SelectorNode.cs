using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : BTNode {


	public SelectorNode(params BTNode[] btns) : base(){
		foreach (BTNode btn in btns) {
			children.Add (btn);
			btn.parent = this;
		}
	}


	public override bool? GetSuccess(){
		foreach (BTNode child in children) {
			if (child.GetSuccess () == null) {
				return null;
			} else if (child.GetSuccess() == true) {
				return true;
			}

		}
		return false;
	}
}
