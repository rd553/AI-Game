using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class NDSelectorNode : SelectorNode {



	// Use this for initialization
	void Start () {
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
