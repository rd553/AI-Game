using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BTNode {





	
	public override bool? GetSuccess ()
	{
		return children [0].GetSuccess ();
	}
}
