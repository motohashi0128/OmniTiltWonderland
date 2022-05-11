using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_change : MonoBehaviour {

	
	public List<GameObject> cameras;

	public List<float> wait_times;
 

	private int cam_num;
	private int cam_max;

	float cam_time;

	public GameObject notepc_gamen;

	// Use this for initialization
	void Start () {

		foreach (GameObject cam in cameras) {
			cam.SetActive (false);
		}
	

		//cameras[0].SetActive(true);

		cam_max = cameras.Count;
		cam_num = 0;
		cam_time = 0.0f;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        cameras[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        
		
		 
		cam_time += Time.deltaTime;
		
		//print (cam_time);
		if (cam_time > wait_times[cam_num]) {
			cam_num ++;
			if(cam_num  > cam_max-1){
				cam_num = 0;
			}
			cam_time = 0.0f;
			foreach (GameObject cam in cameras) {
				cam.SetActive (false);
			}
			cameras[cam_num].SetActive(true);
			if(cam_num == cam_max - 1)
            {
				notepc_gamen.GetComponent<Animator>().enabled = true;

			}
		}

		

		

		
		

	}
}
