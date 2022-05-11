using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_cap : MonoBehaviour
{

    public GameObject targetcap;
    // Start is called before the first frame update
    void Start()
    {
        targetcap.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            targetcap.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("delay_hide", 2.0f);
        }
    }


    void delay_hide()
    {
        targetcap.SetActive(false);
    }
}
