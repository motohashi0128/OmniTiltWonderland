using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//追加

public class objdead : MonoBehaviour

{

    void Start()
    {
        

    }

    void FixedUpdate(){
   Vector3 tmp = this.transform.position;
        if(tmp.y < -300){
           
           //this.gameObject.SetActive(false);
            this.transform.position = new Vector3(0f,30f,0);
             //this.gameObject.SetActive(true);
        }


    }

}