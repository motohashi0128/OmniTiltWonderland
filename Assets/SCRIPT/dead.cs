using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//追加

public class dead : MonoBehaviour

{
    AsyncOperation a;//AsyncOperation型の変数aを宣言
    public float DeadPoint = 4.0f;

    bool changed = false;
    void Start()
    {
        //SceneManager.LoadSceneAsync("GameScene")の返り値(型はAsyncOperation)を変数aに代入
        //a = SceneManager.LoadSceneAsync("start");

        //AsyncOperationの中の変数allowSceneActivationをfalseにする
        //これがtrueになるとシーン移動する
        //a.allowSceneActivation = false;
    }

    // void FixedUpdate(){
    //     Vector3 tmp = this.transform.position;
    //     if(tmp.y < DeadPoint){
    //         a.allowSceneActivation = true;
    //     }


    // }
    
　　 void OnTriggerEnter(Collider other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Finish")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            if (!changed)
            {
                changed = true;
                Invoke("changeScene", 5f);
            }
            
        }
    }
    void changeScene(){
        //a.allowSceneActivation = true;
        FadeManager.Instance.LoadScene("001_main", 2.0f);

    }


}