using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRig : MonoBehaviour
{
    [SerializeField]
    GameObject basketBall;
    [SerializeField]
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = basketBall.transform.position + offset;
    }
}
