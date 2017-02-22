using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;

public abstract class Condition : BTNode {

	private BTNode[] children;

	public override Steering[] GetBehavior(){
		return children [GetConditionMet()].GetBehavior();
	}

	public abstract int GetConditionMet();

}
