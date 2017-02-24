using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTreeMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BehaviourTree bt = gameObject.AddComponent<BehaviourTree> ();

		LeafTetherNode ltn = new LeafTetherNode ("Capsule", 8.5f, 1f);
		LeafStrafeNode lsn = new LeafStrafeNode ("Capsule", 1.0f, 1f);
		LeafWaitForPlayerNode lwfpn = new LeafWaitForPlayerNode("Capsule",10f,0f);
		LeafFireAtPlayerNode lfapn = new LeafFireAtPlayerNode ("Capsule", 2f);


		SequenceNode sn1 = new SequenceNode (ltn,lsn);



		ParallelSequenceNode psn1 = new ParallelSequenceNode (sn1, lfapn);


		LoSInterruptDecorator lid = new LoSInterruptDecorator (psn1, "Capsule", 10f, 1f);
		SequenceNode sn2 = new SequenceNode (lwfpn, lid);


		RootNode r = new RootNode (sn2);
		r.tree = bt;
		bt.setRoot (r);
	}
	

}
