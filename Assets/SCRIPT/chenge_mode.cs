using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chenge_mode : MonoBehaviour
{

    public bool _enter;
    public bool _leave;

    public bool fujikura;
    public bool harada;

     
         
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (_enter && fujikura) {
                other.gameObject.GetComponent<ctrl_iphone>().fujikura_mode = true;
            }

            if (_enter && harada)
            {
                other.gameObject.GetComponent<ctrl_iphone>().harada_mode = true;
            }

            if (_leave)
            {
                other.gameObject.GetComponent<ctrl_iphone>().fujikura_mode = false;
                other.gameObject.GetComponent<ctrl_iphone>().harada_mode = false;

            }
        }
    }
}
