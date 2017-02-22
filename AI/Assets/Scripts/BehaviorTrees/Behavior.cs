using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;

public class Behavior : BTNode {

	List<UnitySteer.Behaviors.Steering> behaviors;


	public override Steering[] GetBehavior(){
		return behaviors.ToArray();
	}
}
