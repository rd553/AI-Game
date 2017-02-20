using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNum : MonoBehaviour {
	public float speed;
	public float fadeSpeed;
	private float a;
	private TextMesh m;

	// Use this for initialization
	void Start () {
		a = 1.0f;

		m = gameObject.GetComponent<TextMesh> ();

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (0, speed, 0);


		a -= fadeSpeed * Time.deltaTime;
		m.color = new Color (m.color.r, m.color.g, m.color.b, a);
		if (a <= 0) {
			Destroy (gameObject );
		}


	}




}
