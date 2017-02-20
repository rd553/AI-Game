using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public MakeWall north;
	public MakeWall south;
	public MakeWall east;
	public MakeWall west;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public MakeWall GetWall(MakeWall.Direction dir){
		switch (dir) {
		case MakeWall.Direction.North:
			return north;
		case MakeWall.Direction.South:
			return south;
		case MakeWall.Direction.East:
			return east;
		case MakeWall.Direction.West:
			return west;
		default  :
			return null;
		}
	}

	public List<MakeWall> GetOpen(){
		List<MakeWall> r = new List<MakeWall> ();

		if (north.Open ())
			r.Add (north);
		if (south.Open ())
			r.Add (south);
		if (east.Open ())
			r.Add (east);
		if (west.Open ())
			r.Add (west);

		return r;

	}
}
