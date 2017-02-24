using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertDecorator : Decorator {

	public InvertDecorator(BTNode child) : base(child){

	}

	public override bool? GetSuccess(){
		


		return !children [0].GetSuccess ();
	}
}
