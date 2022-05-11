using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
//速さ
private bool Grounded;
//方向転換スピード

Animator anim;



void Start(){
    anim=gameObject.GetComponent<Animator>();

}

void FixedUpdate(){

　　　　float v = Input.GetAxisRaw("Vertical");
                if( 0.0f != v)
                {
                anim.SetBool ( "walk", true );
                //Debug.Log("a");
                }
                else
                {
                    anim.SetBool ( "walk", false );
                }   
       if (Grounded == true)//  もし、Groundedがtrueなら、
        {

        }

    }
        void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
        }
    }

}