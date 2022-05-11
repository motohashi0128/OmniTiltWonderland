using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_message : MonoBehaviour
{
    public GameObject show_canvas;
    // Start is called before the first frame update
    void Start()
    {
        show_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            show_canvas.SetActive(true);
        }
    }
}
