using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stolen_view : MonoBehaviour
{
    public float scale = 1.0f;

    int s_w, s_h;
    // Start is called before the first frame update
    void Start()
    {
        s_w = Screen.height;
        s_h = Screen.width;


        this.transform.localScale = new Vector3();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
