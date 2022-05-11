using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 var lookPos = target.position - transform.position;
   	 		
        transform.LookAt(lookPos,new Vector3(0,1,0));
	}
}
