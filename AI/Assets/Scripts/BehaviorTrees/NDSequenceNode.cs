using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NDSequenceNode : SequenceNode {




	public NDSequenceNode(params BTNode[] btns) : base (btns){
		Reshuffle ();
	}

	public override void Reset ()
	{
		Reshuffle ();
		base.Reset ();
	}

	private void Reshuffle(){
		children.FYShuffle ();
	}
}
