using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta_camera_ctrl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject main_camera;
    public GameObject stolen_camera;
    public GameObject meta_camera;

    public GameObject this_cam_change;

    public bool metamode = false;

    GameObject map_setting;
    void Start()
    {
        main_camera.GetComponent<Camera>().enabled = true;
        stolen_camera.SetActive(false);
        meta_camera.SetActive(false);
        this_cam_change.GetComponent<cam_change>().enabled = false;
        map_setting = GameObject.Find("map_flag_set");
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            
            if (!metamode)
            {
                //set_metamode();
                /*
                main_camera.GetComponent<Camera>().enabled = false;
                stolen_camera.SetActive(true);
                meta_camera.SetActive(true);
                metamode = true;
                */
            }
            else if (metamode) { 

            /*
                main_camera.GetComponent<Camera>().enabled = true;
                stolen_camera.SetActive(false);
                meta_camera.SetActive(false);
                metamode = false;
            */
            }
           
            
        }
    }

    public void set_metamode()
    {
        main_camera.GetComponent<Camera>().enabled = false;
        stolen_camera.SetActive(true);
        meta_camera.SetActive(true);
        this_cam_change.GetComponent<cam_change>().enabled = true;
 
        metamode = true;
       // map_setting.GetComponent<map_setting_mastar>().enter_map = false;
    }
}
