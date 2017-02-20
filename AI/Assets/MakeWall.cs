using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWall : MonoBehaviour {

	public enum Types {None, Wall, Door};
	public enum Direction{North, South, East, West};
	public Direction dir;
	public Types type { get; private set; }

	// Use this for initialization
	void Start () {

		type = Types.None;

		/**if(Random.Range(0f,1f)>=0.5f){
			Become (Types.Wall);}
		else { Become (Types.Door);}*/
	}


	public void Become(Types t){

		string prefabName;
		switch (t) {
		case Types.Wall:
			prefabName = "Wall";
			break;
		case Types.Door:
			prefabName = "Doorway";

			break;
		default:
			prefabName = "";
			break;
		}

		if (prefabName != "") {
			GameObject wall = GameObject.Instantiate (Resources.Load (prefabName), gameObject.transform) as GameObject;
			type = t;
		}

	}


	public Direction Opposite(){
		switch (dir) {
		case Direction.North:
			return Direction.South;
		case Direction.South:
			return Direction.North;
		case Direction.East:
			return Direction.West;
		case Direction.West:
			return Direction.East;
		default :
			return Direction.South;
		
		}
	}

		public Vector3 OppositeVector(){
		switch (dir) {
		case Direction.East:
			return new Vector3 (1, 0, 0);
		case Direction.West:
			return new Vector3 (-1, 0, 0);
		case Direction.North:
			return new Vector3 (0, 0, 1);
		case Direction.South:
			return new Vector3 (0, 0, -1);
		default :
			return new Vector3 (1, 0, 0);

		}
		}
	


	public bool Open(){
		return type == Types.None;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
