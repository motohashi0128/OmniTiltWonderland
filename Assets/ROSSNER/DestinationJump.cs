using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace manuel {

public class DestinationJump : MonoBehaviour
{
    
    
    public bool isFirst = false;
    public bool isLast = false;

    public int id = 0;

    void OnTriggerEnter(Collider collider) {
        transform.gameObject.SetActive(false);
        transform.parent.GetComponent<DestinationManager>().UpdateTarget();
        Debug.Log("Waypoint reached");
    }
}

}