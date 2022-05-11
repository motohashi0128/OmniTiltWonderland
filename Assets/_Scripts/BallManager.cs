using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    public GameObject spawnPoint;
    public GameObject Ball;
    public float randRangeXZ;
    public float randRangeY;
    public float Timer;

    private Vector3 SPpos;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        SPpos = spawnPoint.transform.position;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > Timer)
        {
            SPpos = spawnPoint.transform.position;
            SPpos += new Vector3(Random.Range(-randRangeXZ, randRangeXZ), Random.Range(-randRangeY, randRangeY), Random.Range(-randRangeXZ, randRangeXZ));
            Instantiate(Ball, SPpos, Quaternion.identity);
            count = 0;
        }
    }
}
