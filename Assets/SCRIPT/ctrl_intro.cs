using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl_intro : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject toki_ctrl;

    private void Awake()
    {
        if (toki_change_scene.toki_flag)
        {
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
