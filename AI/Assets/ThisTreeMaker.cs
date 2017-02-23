using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTreeMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BehaviourTree bt = gameObject.AddComponent<BehaviourTree> ();

		LeafTetherNode ltn = new LeafTetherNode ("Capsule", 8.5f, 1f);
		SequenceNode sn = new SequenceNode (ltn);
		RootNode r = new RootNode (sn);
		r.tree = bt;
		bt.setRoot (r);
	}
	

}
