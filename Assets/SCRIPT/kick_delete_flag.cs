using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kick_delete_flag : MonoBehaviour
{


    public GameObject harada_map;

    public GameObject delete_all;

    public GameObject reigai;

    public GameObject door; 

    // Start is called before the first frame update

    void Start()
    {
        harada_map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<delete_ready>().delete_ready_flag = true;

            harada_map.SetActive(true);
            delete_all.SetActive(false);
            door.SetActive(false);

            reigai.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
}
