using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sine_move : MonoBehaviour {

	float _timer;
	Vector3 ini_pos;
	float move_p;

	public bool forward;
	public float speed = 1.0f;

	public float scalex = 0.0f;
	public float scaley = 0.0f;
	public float scalez = 0.0f;

	// Use this for initialization
	void Start () {
		_timer = 0.0f;
		ini_pos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime* speed;

		if (forward) {
			move_p = Mathf.Sin (_timer) / 5.0f;
		} else {
			move_p = -Mathf.Sin (_timer) / 5.0f;
		}

		this.transform.position = new Vector3 (ini_pos.x + move_p*scalex,ini_pos.y + move_p*scaley,ini_pos.z + move_p*scalez);
	}
}
