using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_function : MonoBehaviour
{

    public bool icc_kannai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void kick_quit()
    {
        if (!icc_kannai)
        {
            print("quit");
            Application.Quit();
        }
        else
        {
            FadeManager.Instance.LoadScene("001_main", 2.0f);

        }
    }
}
