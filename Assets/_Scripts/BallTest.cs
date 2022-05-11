using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BallTest : MonoBehaviour
{
    [SerializeField]
    GameObject ball, sphere,cam;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BallInst();
                state = 1;
            }
        }
        else if (state == 1)
        {

        }
    }

    void BallInst()
    {
        GameObject basketBall = Instantiate(ball, sphere.transform.position, Quaternion.identity);
        cam.transform.parent = basketBall.transform;
        XRDevice.DisableAutoXRCameraTracking(cam.GetComponent<Camera>(),true);
        
    }
}
