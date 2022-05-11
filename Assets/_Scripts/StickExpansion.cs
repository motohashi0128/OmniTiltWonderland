using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickExpansion : MonoBehaviour
{

    public GameObject Handle;
    public GameObject Leg;
    public float StickLength;

    private float dist;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Handle.transform.position, Leg.transform.position);
        Handle.transform.LookAt(Leg.transform);
        Handle.transform.localScale = new Vector3(1, 1, dist*StickLength);
    }
}