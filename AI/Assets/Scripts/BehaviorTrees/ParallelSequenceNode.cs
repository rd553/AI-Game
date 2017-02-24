using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelSequenceNode : SequenceNode {


	public ParallelSequenceNode(params BTNode[] btns) : base(){
		foreach (BTNode btn in btns) {
			children.Add (btn);
			btn.parent = this;
		}
	}

	public override bool? GetSuccess(){

		if (succeeded != null) {
			return succeeded;
		}

		bool? r = true;

		foreach (BTNode child in children) {
			
			if (child.GetSuccess () == false) {
				foreach (BTNode c in children) {
					c.OnReturn (false);
					OnReturn (false);
					return false;
				}
			} else if (child.GetSuccess () == null) {
				r = null; continue;}

		}


		OnReturn (r);
		return r;
	}
}


