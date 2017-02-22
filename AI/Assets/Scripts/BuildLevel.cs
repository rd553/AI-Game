using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildLevel : MonoBehaviour {



	public GameObject player;
	public int numberOfRooms;
	public static float GRID_SIZE = 45;

	private static System.Random random = new System.Random ();
	private Dictionary<Vector3,Room> rooms;


	void Start () {
			rooms = new Dictionary<Vector3,Room> ();

		//make the first room at 0,0
		makeRoom (Vector3.zero);


		while (numberOfRooms > 0) {
			

			connectNewRoom ();


		}

		//create a starting room with only one exit, and move the player to it
		Vector3? startcoords = null;
		while (startcoords == null) {
			startcoords = connectNewRoom ();
		}
		Room startroom;
		rooms.TryGetValue ((Vector3)startcoords, out startroom);
		Vector3 p = startroom.gameObject.transform.position;
		player.transform.position = new Vector3 (p.x, 1.5f, p.z);

		Wallify (startroom);
		rooms.Remove ((Vector3)startcoords);


		Vector3? endcoords = null;
		while (endcoords == null) {
			endcoords = connectNewRoom ();
		}
		Room endroom;
		rooms.TryGetValue ((Vector3)endcoords, out endroom);
		endroom.GetWall (endroom.GetClosed () [0].Opposite ()).Become (MakeWall.Types.EndDoor);

		//We're done, so all remaining open directions become walls
		foreach (KeyValuePair<Vector3, Room> kvp in rooms) {
			Wallify (kvp.Value);
		}
	}

	private Vector3 RandomRoom(){
		List<Vector3> keys = rooms.Keys.ToList ();
		Vector3 coords = keys [random.Next (keys.Count)];
		return coords;
	}


	private void Wallify(Room room){
		foreach (MakeWall mw in room.GetOpen()) {
			mw.Become (MakeWall.Types.Wall);
		}
	}
	private Vector3? connectNewRoom(){
		
		Vector3 coords = RandomRoom ();
		Room selected;
		//pick a random room
		rooms.TryGetValue (coords, out selected);

		//make sure it has a space
		List<MakeWall> dirs = selected.GetComponent<Room> ().GetOpen ();
		if (dirs.Count < 1) {
			return null;
		}
		MakeWall dir = dirs [random.Next (dirs.Count)];
		Vector3 newcoords = dir.OppositeVector () + coords;
		Room newRoom = makeRoom (newcoords);
		//and make sure that space doesn't lead to a pre-existing room
		if (newRoom == null) {
			return null;
		}
		//turn that direction into a doorway
		newRoom.GetWall (dir.Opposite ()).Become(MakeWall.Types.Door);
		dir.Become (MakeWall.Types.Door);

		//and put a corridor in between
		GameObject corridor = GameObject.Instantiate (Resources.Load ("Corridor"),dir.gameObject.transform) as GameObject;
		corridor.transform.parent = dir.transform;
		return newcoords;
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


