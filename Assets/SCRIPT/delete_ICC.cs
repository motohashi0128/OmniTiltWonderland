using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_ICC : MonoBehaviour
{

    bool  icc_delete = false;

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

        if (other.CompareTag("Player") && !icc_delete)
        {

            
        }
    }
}
