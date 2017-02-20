using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildLevel : MonoBehaviour {




	public int numberOfRooms;
	public static float GRID_SIZE = 45;
	static System.Random random = new System.Random ();
		private Dictionary<Vector3,Room> rooms;

	// Use this for initialization
	void Start () {
			rooms = new Dictionary<Vector3,Room> ();
		makeRoom (Vector3.zero);

		while (numberOfRooms > 0) {
			List<Vector3> keys = rooms.Keys.ToList ();
			Vector3 coords = keys [random.Next (keys.Count)];
			    
			Room selected;
			rooms.TryGetValue (coords, out selected);


			List<MakeWall> dirs = selected.GetComponent<Room> ().GetOpen ();
			if (dirs.Count < 1) {
				continue;
			}
			MakeWall dir = dirs [random.Next (dirs.Count)];
			Room newRoom = makeRoom (dir.OppositeVector () + coords);
			if (newRoom == null) {
				continue;
			}
			newRoom.GetWall (dir.Opposite ()).Become(MakeWall.Types.Door);




			dir.Become (MakeWall.Types.Door);
			GameObject corridor = GameObject.Instantiate (Resources.Load ("Corridor"),dir.gameObject.transform) as GameObject;
			corridor.transform.parent = dir.transform;


		}


		//All open directions become walls
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
		room.gameObject.transform.position = new Vector3 (c.x*45, 0, c.z*45);



		rooms.Add(c,room.GetComponent<Room>());
		numberOfRooms--;
		return room.GetComponent<Room> ();
	}


	// Update is called once per frame
	void Update () {
		
	}


}


