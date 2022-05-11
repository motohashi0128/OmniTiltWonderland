using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harada_camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float delaytime = 5.0f;

    public Camera main_cam;

    public GameObject  harada_cam;

    bool changed = false;

    void Start()
    {
        harada_cam.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")  && !changed)
        {
            
            harada_cam.SetActive(true);
            Invoke("do_transparent", 2.0f);
            Invoke("cam_back", 9.0f);
            main_cam.enabled = false;
            print("calll");
        }
    }

     void do_transparent()
    {
        gameObject.GetComponent<harada_color_ctrl>().harada_set_floor();
    }

     void cam_back()
    {

        changed = true;
        harada_cam.SetActive(false);
        //Invoke("scene_change", 5.0f);
        main_cam.enabled = true;
    }
    
}
