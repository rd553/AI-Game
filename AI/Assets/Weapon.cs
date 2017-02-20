using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject shotAperture;
	public float shotSpeed;
	public float timeBetweenShots;
	public float maxAmmo;
	public bool automatic;

	float ammo;
	float timeToNextShot;

	// Use this for initialization
	void Start () {
		timeToNextShot = 0;
		ammo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToNextShot > 0) {
			timeToNextShot -= Time.deltaTime;
		}
	}

	public float Fire(){
		//should probably switch to pooling at some point

		if (timeToNextShot <= 0) {
			GameObject shot = GameObject.Instantiate (Resources.Load ("Bullet")) as GameObject;
			shot.transform.position = shotAperture.transform.position;
			shot.transform.rotation = shotAperture.transform.rotation;

			shot.GetComponent<Rigidbody> ().AddForce (shot.transform.forward * shotSpeed, ForceMode.Impulse);
			timeToNextShot = timeBetweenShots;
			return 0;
		} else
			return timeToNextShot;
	}
}
