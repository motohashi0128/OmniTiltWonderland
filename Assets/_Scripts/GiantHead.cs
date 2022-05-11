using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHead : MonoBehaviour
{
    [SerializeField]
    GameObject cam,headPos,HeadSphere;

    int state;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        HeadSphere.transform.position = headPos.transform.position;
        HeadSphere.GetComponent<Rigidbody>().isKinematic = true;
        HeadSphere.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = HeadSphere.transform.position;
        if (state == 0)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                HeadSphere.GetComponent<Rigidbody>().isKinematic = false;
                HeadSphere.GetComponent<Rigidbody>().useGravity = true;
                state = 1;
            }
        }
        else if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                HeadSphere.GetComponent<Rigidbody>().isKinematic = true;
                HeadSphere.GetComponent<Rigidbody>().useGravity = false;
                HeadSphere.transform.position = headPos.transform.position;
                state = 0;
            }
        }
    }
}
