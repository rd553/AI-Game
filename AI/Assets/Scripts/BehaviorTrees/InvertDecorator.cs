using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertDecorator : Decorator {

	public override bool? GetSuccess(){
		return !children [0].GetSuccess ();
	}
}
