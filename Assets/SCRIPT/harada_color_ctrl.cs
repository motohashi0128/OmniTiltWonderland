using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harada_color_ctrl : MonoBehaviour
{

    public GameObject target_obj;
    public GameObject target_obj2;
 
    Material this_mat;
    Material this_mat2;
 
    public float floor_alp = 1.0f;
    // Start is called before the first frame update

    float target_alp = 1.0f;
    bool _set = false;
    

    void Start()
    {
        this_mat = target_obj.gameObject.GetComponent<Renderer>().material;

        this_mat2 = target_obj2.gameObject.GetComponent<Renderer>().material;
        //harada_list[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

    }

    // Update is called once per frame
    void Update()
    {
        if (_set)
        {
            floor_alp += (target_alp - floor_alp) / 60.0f;
            this_mat.SetColor("_Color", new Color(1, 1, 1, floor_alp));
            this_mat2.SetColor("_Color", new Color(1, 1, 1, floor_alp));
 

            if (floor_alp  < 0.01f)
            {
                floor_alp = 0.0f;
                _set = false;
            }
        }

    }

     public void harada_set_floor()
    {
        _set = true;
        target_alp = 0.0f;
    }
}
