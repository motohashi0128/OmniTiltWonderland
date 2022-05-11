using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_zoom : MonoBehaviour {

	private float cam_zoom_p  = 2.5f;

	public float cam_zoom_limit = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cam_zoom_p += Input.GetAxis ("Mouse ScrollWheel")/10.0f;

		if (cam_zoom_p < 0.5f) {
			cam_zoom_p = 0.5f;
		}
		if (cam_zoom_p > cam_zoom_limit) {
		
			cam_zoom_p = cam_zoom_limit;
		}
			
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y, -cam_zoom_p);
	}
}
