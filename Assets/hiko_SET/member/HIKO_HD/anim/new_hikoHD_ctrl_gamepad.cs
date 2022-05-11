using UnityEngine;
using System.Collections;

public class new_hikoHD_ctrl_gamepad : MonoBehaviour {
	private Animator animator;
	private bool first_cam_flag = true;

	public bool first_cam_start = true;
	public Camera camera1;

	public GameObject camera2;




	private float act_H,tar_H;
	private float act_V,tar_V;
	private float rot_H, rot_V;
	private float rot_a_H, rot_a_V;
	private float c_rot;
	private float c_a_rot;
	private Vector3 cam_rot;
	//private GameObject _uwwebkit;

	private float _distance;

	private float _speed;
	private float p_distance,c_distance;


	private Quaternion this_pos;
	private Quaternion ini_this_pos;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		/*
		GameObject.Find("thirdCamera").GetComponent<Camera>().enebled = false;
		GameObject.Find("firstCamera").GetComponent<Camera>().enebled = true;
*/

		if (first_cam_start) {
			first_cam_flag = true;
			camera1.gameObject.SetActive (true);
			camera2.gameObject.SetActive (false);
		} else {
			first_cam_flag = false;
			camera1.gameObject.SetActive (false);
			camera2.gameObject.SetActive (true);
		};
	
		//_uwwebkit = GameObject.Find ("WebTexture");

		act_H = 0.0f;
		act_V = 0.0f;

		tar_H = 0.0f;
		tar_V = 0.0f;
			
		rot_H = 0.0f;
		rot_V = 0.0f;
		rot_a_H = 0.0f;
		rot_a_V = 0.0f;
		c_rot = 0.0f;
		c_a_rot = 0.0f;

		_speed = 0.0f;
		p_distance = 0.0f;
		c_distance = 0.0f;
		this_pos = transform.rotation;
		ini_this_pos = transform.rotation;
	}

	// Update is called once per frame
	void Update () {

		tar_V = Input.GetAxis ("Vertical");
		tar_H = Input.GetAxis ("Horizontal");

		act_V += (tar_V - act_V) / 4.0f;
		act_H += (tar_H - act_H) / 4.0f;

		this_pos = transform.rotation;

		//print ("act_V:"+ act_V + "  act_H:"+act_H);
		p_distance = _distance;

		_distance = Mathf.Pow ((0.0f - tar_V) * (0.0f - tar_V) + (0.0f - tar_H) * (0.0f - tar_H),0.5f);

		c_distance = _distance;

		_speed = Mathf.Abs(c_distance - p_distance);

		//print ("speed :" + _speed + " turn :" + _speed * act_H);

		//print (Input.GetAxis ("Vertical"));
		if (_distance > 0.05f) {
			rot_V = Input.GetAxis ("Vertical");
			rot_H = Input.GetAxis ("Horizontal");
			cam_rot = camera2.transform.rotation.eulerAngles;
		} else {
			rot_V = 0.0f;
			rot_H = 0.0f;
		}

		rot_V = Input.GetAxis ("Vertical");
		rot_H = Input.GetAxis ("Horizontal");
			
		rot_a_H += (rot_H - rot_a_H) / 10.0f;
		rot_a_V += (rot_V - rot_a_V) / 10.0f;
	

		c_rot = (Mathf.Atan2 (rot_a_H, rot_a_V)* Mathf.Rad2Deg)+180-ini_this_pos.eulerAngles.y;
		//print ("rot_V : " + rot_V);
		//print ("rot_H : " + rot_H);
		//print ("con_rot : " + c_rot);
		Vector3 new_rot = new Vector3 (this_pos.eulerAngles.x, -(c_rot -cam_rot.y), this_pos.eulerAngles.z);

		transform.rotation = Quaternion.Euler(new_rot);
		//print ("this_rot : " + (360-this_pos.eulerAngles.y));
		/*
		if (Input.GetKeyUp ("c")) {
			if (!first_cam_flag) {
				first_cam_flag = true;
				camera2.gameObject.SetActive(false);
				camera1.gameObject.SetActive(true);
			} else {
				first_cam_flag = false;
				camera1.gameObject.SetActive(false);
				camera2.gameObject.SetActive(true);
			}
		}
		*/


		//print ("this_rot : "+this_pos.eulerAngles);
		//print ("cam_rot : "+camera2.transform.rotation.eulerAngles);
	


		animator.SetFloat ("VSpeed", act_V);
		animator.SetFloat ("HSpeed", act_H);
		/*
		animator.SetFloat ("VSpeed", Input.GetAxis ("Vertical"));
		animator.SetFloat ("HSpeed", Input.GetAxis ("Horizontal"));
		*/
		animator.SetFloat ("Forward", _distance);

		//print (Input.GetAxis ("Vertical"));
		//print (Input.GetAxis ("Horizontal"));


			if (Input.GetButtonDown ("Jump")) {
				animator.SetBool ("jumping", true);
				Invoke ("StopJumping", 0.1f);
			}
			
		if (Input.GetButtonDown ("Fire3")) {
			animator.SetBool ("punch", true);
			Invoke ("StopPunching", 0.1f);
		}

		if (Input.GetButtonDown ("Fire2")) {
			animator.SetBool ("down", true);
			Invoke ("StopDown", 3f);
		}
		if (Input.GetButtonDown ("Fire1")) {
			animator.SetBool ("clap", true);
			Invoke ("StopClap", 3f);
		}




			if (Input.GetKey ("q")) {
				if ((Input.GetAxis ("Vertical") == 0.0f) && (Input.GetAxis ("Horizontal") == 0.0f)) {
					animator.SetBool ("turnL", true);
				}
			} else {
				animator.SetBool ("turnL", false);
			}

			if (Input.GetKey ("e")) {
				if ((Input.GetAxis ("Vertical") == 0.0f) && (Input.GetAxis ("Horizontal") == 0.0f)) {
					animator.SetBool ("turnR", true);
				}
			} else {
				animator.SetBool ("turnR", false);
			}

			if (Input.GetKey ("w") && Input.GetKey ("left shift") || Input.GetKey ("w") && Input.GetKey ("right shift") || Input.GetKey ("up") && Input.GetKey ("left shift")) {
				if ((Input.GetAxis ("Vertical") > 0.5f) && (Input.GetAxis ("Horizontal") == 0.0f)) {
					animator.SetBool ("Running", true);
				}
			} else {
				animator.SetBool ("Running", false);
			}

			if (Input.GetKey ("w") && Input.GetKey ("e")) {
				transform.Rotate (Vector3.up * Time.deltaTime * 80.0f);
			}
			if (Input.GetKey ("w") && Input.GetKey ("q")) {
				transform.Rotate (Vector3.down * Time.deltaTime * 80.0f);
			}

			if (Input.GetKey ("s") && Input.GetKey ("e")) {
				transform.Rotate (Vector3.up * Time.deltaTime * 80.0f);
			}
			if (Input.GetKey ("s") && Input.GetKey ("q")) {
				transform.Rotate (Vector3.down * Time.deltaTime * 80.0f);
			}



	}

	void StopJumping(){

		animator.SetBool ("jumping", false);
	}

	void StopPunching(){

		animator.SetBool ("punch", false);
	}
	void StopDown(){

		animator.SetBool ("down", false);
	}
	void StopClap(){

		animator.SetBool ("clap", false);
	}
	void SelectCamera(int cameraIndex)
	{


	}
}
