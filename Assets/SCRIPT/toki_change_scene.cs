using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toki_change_scene : MonoBehaviour
{

    public float delaytime = 5.0f;

    public Camera main_cam;

    public GameObject toki_cam;

    public static Vector3 hiko_gpos;
    public static Quaternion hiko_grot;
    public static bool toki_flag = false;

    public GameObject hiko;
    // Start is called before the first frame update
    void Start()
    {
        toki_cam.SetActive(false);
        if (toki_flag)
        {
            print("rerere");
            print(hiko_gpos);
            print(hiko_gpos);
            hiko.transform.position = hiko_gpos;
            hiko.transform.rotation = hiko_grot;
            
        }
      //  toki_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!toki_flag)
            {
                toki_flag = true;
                toki_cam.SetActive(true);
                Invoke("scene_change", 5.0f);
                main_cam.enabled = false;
                print("calll");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && main_cam.enabled)
        {
            toki_flag = false;
        }
    }

    void scene_change()
    {
        hiko_gpos = hiko.transform.position;
        hiko_grot = hiko.transform.rotation;
        toki_flag = true;
        print(hiko_gpos);
        FadeManager.Instance.LoadScene("octopas", 2.0f);

    }
}
