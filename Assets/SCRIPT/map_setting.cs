using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class map_setting : MonoBehaviour
{

    public GameObject setting_master;


    public bool _enter;
    public bool _leave;

    

    

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
            bool _flag = other.gameObject.GetComponent<delete_ready>().delete_ready_flag;

            if (_enter && _flag)
            {
                setting_master.GetComponent<map_setting_mastar>().enter_map = true;
            }

            if (_leave && _flag)
            {
                setting_master.GetComponent<map_setting_mastar>().enter_map = false;

            }


        }
    }
}
