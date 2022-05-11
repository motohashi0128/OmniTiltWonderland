using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToStart : MonoBehaviour {
	private float wait_time = 0.0f;

	public int limit_time = 20;

	private Vector3 character_pos;
	private Quaternion character_rot;

	private float _dis;

	public bool _enable = false;
	void Awake(){
		//最初の座標を保存
		character_pos = this.transform.position;
		character_rot = this.transform.rotation;
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_dis = Vector3.Distance(character_pos, this.transform.position);
		//print (_dis);
		// 経過時間を計測
		wait_time += Time.deltaTime;
		//print (wait_time);
		if (wait_time > limit_time) {
			wait_time = 0.0f;

			//シーンごと読み込み直す（ライティング設定に注意）
			//Application.LoadLevel("001");


			//最初の座標に戻す
			if (_dis > 3.0f && _enable == true) {
				this.transform.position = character_pos;
				this.transform.rotation = character_rot;
			}

		}


		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.1) {
			wait_time = 0.0f;

		}
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.1) {
			wait_time = 0.0f;

		}
		if (Mathf.Abs (Input.GetAxis ("Mouse X")) > 0.1) {
			wait_time = 0.0f;
		;
		}
		if (Mathf.Abs (Input.GetAxis ("Mouse Y")) > 0.1) {
			wait_time = 0.0f;

		}
			

		if (Input.GetButtonDown ("Jump")) {
			wait_time = 0.0f;

		}

		if (Input.GetButtonDown ("Fire3")) {
			wait_time = 0.0f;


		}

		if (Input.GetButtonDown ("Fire2")) {
			wait_time = 0.0f;


		}
		if (Input.GetButtonDown ("Fire1")) {
			wait_time = 0.0f;


		}
		if(Input.anyKeyDown){
			wait_time = 0.0f;
		}
	}
}
