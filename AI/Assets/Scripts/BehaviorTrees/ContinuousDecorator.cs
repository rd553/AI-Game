using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDecorator : Decorator {

	public ContinuousDecorator(BTNode child) : base(child){

	}

	public override bool? GetSuccess ()
	{
		bool? b = children [0].GetSuccess ();

		if (b == true) {
			children [0].Reset ();
			return null;
		} else
			return b;
	}
}
