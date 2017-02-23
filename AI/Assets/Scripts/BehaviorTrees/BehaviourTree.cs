using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour {

	public RootNode root;

	void Update(){
		if (root.GetSuccess()!=null) {
			root.Reset ();
		}
	}

	public void setRoot(RootNode r){
		root = r;
	}
}
