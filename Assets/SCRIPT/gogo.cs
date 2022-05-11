using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//追加

public class gogo : MonoBehaviour

{
    AsyncOperation a;//AsyncOperation型の変数aを宣言
    void Start()
    {
        //SceneManager.LoadSceneAsync("GameScene")の返り値(型はAsyncOperation)を変数aに代入
        a = SceneManager.LoadSceneAsync("octopas");

        //AsyncOperationの中の変数allowSceneActivationをfalseにする
        //これがtrueになるとシーン移動する
        a.allowSceneActivation = false;
    }
     void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){



        a.allowSceneActivation = true;         
        }
     }

}