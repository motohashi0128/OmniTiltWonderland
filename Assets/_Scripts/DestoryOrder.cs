using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOrder : MonoBehaviour
{
    public float TimeLimit;
    float n;
    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        n += Time.deltaTime;
        if (n > TimeLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
