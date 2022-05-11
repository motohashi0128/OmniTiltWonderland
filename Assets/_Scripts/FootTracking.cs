using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTracking : MonoBehaviour
{
    [SerializeField]
    GameObject floor, tracker, shoe;
    [SerializeField]
    bool minusX, minusY, minusZ,yOffset;
    [SerializeField]
    Vector3 offset;
    float X, Y, Z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (minusX)
            X = -1;
        else
            X = 1;
        if (minusY)
            Y = -1;
        else
            Y = 1;
        if (minusZ)
            Z = -1;
        else
            Z = 1;
        shoe.transform.rotation = Quaternion.Euler(new Vector3(X * tracker.transform.eulerAngles.x, Y * tracker.transform.eulerAngles.y - 90, Z * tracker.transform.eulerAngles.z) - floor.transform.rotation.eulerAngles + offset) ;
    }
}
