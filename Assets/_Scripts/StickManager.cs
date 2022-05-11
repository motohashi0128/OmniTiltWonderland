using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tracker;
    public GameObject stick;
    public GameObject floor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stick.transform.position = tracker.transform.position;
        stick.transform.rotation = Quaternion.Euler(tracker.transform.rotation.eulerAngles +floor.transform.rotation.eulerAngles);
    }
}
