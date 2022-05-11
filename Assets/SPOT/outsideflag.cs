using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsideflag : MonoBehaviour
{
    public GameObject spot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("GameController")){
            spot.GetComponent<Collider>().enabled = true;
        }
    }
}
