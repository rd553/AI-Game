using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildLevel : MonoBehaviour {




	public int numberOfRooms;
	public static float GRID_SIZE = 45;

	private static System.Random random = new System.Random ();
	private Dictionary<Vector3,Room> rooms;


	void Start () {
			rooms = new Dictionary<Vector3,Room> ();

		//make the first room at 0,0
		makeRoom (Vector3.zero);

		while (numberOfRooms > 0) {
			//pick a random room
			List<Vector3> keys = rooms.Keys.ToList ();
			Vector3 coords = keys [random.Next (keys.Count)];
			    
			Room selected;
			rooms.TryGetValue (coords, out selected);

			//make sure it has a space
			List<MakeWall> dirs = selected.GetComponent<Room> ().GetOpen ();
			if (dirs.Count < 1) {
				continue;
			}
			MakeWall dir = dirs [random.Next (dirs.Count)];
			Room newRoom = makeRoom (dir.OppositeVector () + coords);
			//and make sure that space doesn't lead to a pre-existing room
			if (newRoom == null) {
				continue;
			}
			//turn that direction into a doorway
			newRoom.GetWall (dir.Opposite ()).Become(MakeWall.Types.Door);
			dir.Become (MakeWall.Types.Door);

			//and put a corridor in between
			GameObject corridor = GameObject.Instantiate (Resources.Load ("Corridor"),dir.gameObject.transform) as GameObject;
			corridor.transform.parent = dir.transform;


		}


		//We're done, so all remaining open directions become walls
		foreach (KeyValuePair<Vector3, Room> kvp in rooms) {
			foreach (MakeWall mw in kvp.Value.GetOpen()) {
				mw.Become (MakeWall.Types.Wall);
			}
		}
	}


	private Room makeRoom(Vector3 c){
		if (rooms.ContainsKey (c)) {
			return null;
		}

		GameObject room = GameObject.Instantiate (Resources.Load ("Room")) as GameObject;
		room.gameObject.transform.position = new Vector3 (c.x*GRID_SIZE, 0, c.z*GRID_SIZE);



		rooms.Add(c,room.GetComponent<Room>());
		numberOfRooms--;
		return room.GetComponent<Room> ();
	}


	// Update is called once per frame
	void Update () {
		
	}


}


