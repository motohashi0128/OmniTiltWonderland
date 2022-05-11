using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_visible : MonoBehaviour
{

    public bool _visible = false;

    bool match_name = false;
    bool cam_visible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(match_name == true &&cam_visible == true)
        {
           // _visible = true;
        }
        else
        {
            _visible = false;
        }

        if (Input.GetMouseButtonDown(0)  && _visible == true )
        {
            Invoke("set_visible", 1.0f);
        }
    }

    void OnWillRenderObject()
    {
//        Debug.Log(Camera.current.name);
         if (Camera.current.name == "iphone_cam")
        {
            match_name = true;
        }
    }
    void OnBecameVisible ()
    {
        cam_visible = true;
        Debug.Log("OnBecameVisible");
    }

    void OnBecameInvisible()
    {
        match_name = false;
        cam_visible = false; 
        Debug.Log("OnBecameInvisible");
    }

    void set_visible()
    {
        this.gameObject.layer = 0;

    }
}

