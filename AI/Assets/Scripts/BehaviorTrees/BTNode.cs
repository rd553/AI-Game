using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;

public abstract class BTNode {



	protected List<BTNode> children;

	public abstract Steering[] GetBehavior();



}
