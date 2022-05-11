using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_cam : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var lookPos = target.position - transform.position;
		lookPos.y = 0;
		transform.LookAt(target);

	}
}
