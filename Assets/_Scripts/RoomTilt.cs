using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTilt : MonoBehaviour
{
    public GameObject tracker;
    public GameObject floor;
    public GameObject StickA;
    public GameObject StickB;
    public GameObject Cam;
    public GameObject Ball;
    public GameObject ballPos;
    public GameObject COMass;
    public GameObject fenceCol;
    public GameObject shoes;

    [SerializeField]
    float coefficient;
    [SerializeField]
    int listLength;
    [SerializeField]
    bool VerticalLock;
    [SerializeField]
    bool RigLock;
    [SerializeField]
    bool isFallDelayOn;
    [SerializeField]
    float delayTime;

    [SerializeField]
    bool rotreverseX = false;
    [SerializeField]
    bool rotreverseY = false;
    [SerializeField]
    bool rotreverseZ = false;
    float revx, revy, revz;

    [SerializeField]
    bool rotLockX = false;
    [SerializeField]
    bool rotLockY = false;
    [SerializeField]
    bool rotLockZ = false;

    List<Quaternion> rotMemory;

    private Vector3 memoriedRot;
    private Vector3 rotDifference;
    private Vector3 massPos;
    private Vector3 floorPos;
    private Vector3 sum;
    private Quaternion rem;
    private int state, intCounter;
    private float timeCounter;
    int debugCount;
    bool plusminusZ,plusminusX;
    // Start is called before the first frame update
    void Start()
    {
        floorPos = floor.transform.position;
        massPos = Cam.GetComponent<Rigidbody>().centerOfMass;
        rotMemory = new List<Quaternion>();
        state = 0;
        intCounter = 0;
        timeCounter = 0;
        rem = tracker.transform.rotation;
        debugCount = 0;
        Cam.GetComponent<Rigidbody>().centerOfMass = COMass.transform.localPosition;
        //listLength = 0;
        //memoriedRot = tracker.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.rotation = Quaternion.Euler(Nomalize()*coefficient);
        //cam.transform.rotation = Quaternion.Euler(tracker.transform.rotation.eulerAngles* coefficient);
        if (rotreverseX)
            revx = -1;
        else
            revx = 1;
        if (rotreverseY)
            revy = -1;
        else
            revy = 1;
        if (rotreverseZ)
            revz = -1;
        else
            revz = 1;
        if (state == 0)
        {
            floor.transform.rotation = Quaternion.Euler(Average().x * coefficient, Average().y, Average().z * coefficient);
            //Debug.Log(floor.transform.rotation.eulerAngles+", "+ Average().x+", "+tracker.transform.rotation.eulerAngles);
            //shoes.transform.rotation = floor.transform.rotation;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ball.transform.position = floorPos + new Vector3(0, 3, 0);   
            }
            //RigidbodyLock();
            
            if (!VerticalLock)
                return;
            if (plusminusZ && 90 < floor.transform.rotation.eulerAngles.z && floor.transform.rotation.eulerAngles.z < 180) {
                state = 1;
            }
            if (!plusminusZ && 180 < floor.transform.rotation.eulerAngles.z && floor.transform.rotation.eulerAngles.z < 270)
            {
                state = 2;
            }
        } else if (state == 1)
        {
            floor.transform.rotation = Quaternion.Euler(Average().x, Average().y, 90 + Average().z);
        }
        else if (state == 2)
        {
            floor.transform.rotation = Quaternion.Euler(Average().x, Average().y, -90 + Average().z);
        } else if (state == 3)
        {
            FallDelay();
        } else if (state == 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                floor.transform.position = floorPos;
                Ball.transform.position = floorPos + new Vector3(0, 3, 0);
                floor.GetComponent<Rigidbody>().isKinematic = true;
                floor.GetComponent<Rigidbody>().useGravity = false;
                fenceCol.SetActive(true);
                state = 0;
            }
        }
    }

    void FallDelay()
    {
        if (isFallDelayOn)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter > delayTime)
            {
                timeCounter = 0;
                Cam.GetComponent<Rigidbody>().isKinematic = false;
                Cam.GetComponent<Rigidbody>().useGravity = true;
                Cam.GetComponent<Rigidbody>().centerOfMass = massPos;
                Cam.GetComponent<Rigidbody>().freezeRotation = false;
                state = 4;
            }
        }
        else
        {
            Cam.GetComponent<Rigidbody>().isKinematic = false;
            Cam.GetComponent<Rigidbody>().useGravity = true;
            Cam.GetComponent<Rigidbody>().centerOfMass = massPos;
            Cam.GetComponent<Rigidbody>().freezeRotation = false;
            state = 4;
        }
 
    }
    void RigidbodyLock()
    {
        if (!RigLock)
            return;

        
        if ((plusminusZ && 90 < floor.transform.rotation.eulerAngles.z && floor.transform.rotation.eulerAngles.z < 180) || (!plusminusZ && 180 < floor.transform.rotation.eulerAngles.z && floor.transform.rotation.eulerAngles.z < 270)  || (plusminusX && 90 < floor.transform.rotation.eulerAngles.x && floor.transform.rotation.eulerAngles.x < 180) || (!plusminusX && 180 < floor.transform.rotation.eulerAngles.x && floor.transform.rotation.eulerAngles.x < 270))
        {
            floor.GetComponent<Rigidbody>().isKinematic = false;
            floor.GetComponent<Rigidbody>().useGravity = true;

            /*StickA.transform.parent = null;
            StickA.GetComponent<Rigidbody>().isKinematic = false;
            StickA.GetComponent<Rigidbody>().useGravity = true;

            StickB.transform.parent = null;
            StickB.GetComponent<Rigidbody>().isKinematic = false;
            StickB.GetComponent<Rigidbody>().useGravity = true;*/

            fenceCol.SetActive(false);

            state = 3;
        }
    }
    Vector3 Average()
    {
        rotMemory.Add(tracker.transform.rotation);
        if (rotMemory.Count == listLength)
        {
            Vector3 sum = Vector3.zero;
            int modeX = 0, modeY = 0, modeZ = 0;
            for (int i = 0; i < listLength; i++)
            {
                if (i == 0)
                {
                    modeX = (int)(rotMemory[i].eulerAngles.x / 90);
                    modeY = (int)(rotMemory[i].eulerAngles.y / 90);
                    modeZ = (int)(rotMemory[i].eulerAngles.z / 90);
                    //Debug.Log(rotMemory[i].eulerAngles.x + ", " + modeX);
                    sum += rotMemory[i].eulerAngles;
                }
                else
                {
                    sum += new Vector3(Adjust(rotMemory[i].eulerAngles.x, modeX), Adjust(rotMemory[i].eulerAngles.y, modeY), Adjust(rotMemory[i].eulerAngles.z, modeZ));
                }
            }

            float rotx, roty, rotz;

            if (rotLockX)
                rotx = 0;
            else
                rotx = (sum.x / listLength)*revx;
            if (rotLockY)
                roty = 0;
            else
                roty = ((sum.y / listLength) )*revy;
            if (rotLockZ)
                rotz = 0;
            else
                rotz = (sum.z / listLength)*revz;


            sum = new Vector3(rotx,roty - 90, rotz);

            rotMemory.RemoveAt(0);

            if(modeZ <= 1)
            {
                plusminusZ = true;
            }
            else if (modeZ > 2)
            {
                plusminusZ = false;
            }

            if (modeX <= 1)
            {
                plusminusX = true;
            }
            else if (modeX > 2)
            {
                plusminusX = false;
            }

            return sum;
        }
        else
        {
            Debug.Log("リストが埋まっていません");
            return Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state != 0)
            return;
        if(other.gameObject.tag == "floor")
        {
            floor.GetComponent<Rigidbody>().isKinematic = false;
            floor.GetComponent<Rigidbody>().useGravity = true;

            fenceCol.SetActive(false);

            state = 3;
        }
    }

    float Adjust(float a, int mode)
    {
        switch (mode)
        {
            case 0:
                if (180 < a)
                    a -= 360;
                break;
            case 3:
                if (a <= 180)
                    a += 360;
                break;
            default:
                break;
        }
        return a;
    }
    Vector3 Nomalize()
    {
        rotMemory.Add(tracker.transform.rotation);
        Debug.Log(debugCount + "tracker" + tracker.transform.rotation.eulerAngles);
        intCounter++;
        if (intCounter > listLength - 1)
        {
            Vector3 s = sum;
            sum = Vector3.zero;


            for (int i = 0; i < listLength; i++)
            {
                if (i == 0)
                {
                    Debug.Log(debugCount + i + ": " + rotMemory[i].eulerAngles + rem.eulerAngles);
                    sum += new Vector3(AdjustRot(rotMemory[i].eulerAngles.x, rem.eulerAngles.x), AdjustRot(rotMemory[i].eulerAngles.y, rem.eulerAngles.y), AdjustRot(rotMemory[i].eulerAngles.z, rem.eulerAngles.z));
                }
                else
                {
                    Debug.Log(debugCount + i + ": " + rotMemory[i].eulerAngles + rotMemory[i - 1].eulerAngles);
                    sum += new Vector3(AdjustRot(rotMemory[i].eulerAngles.x, rotMemory[i - 1].eulerAngles.x), AdjustRot(rotMemory[i].eulerAngles.y, rotMemory[i - 1].eulerAngles.y), AdjustRot(rotMemory[i].eulerAngles.z, rotMemory[i - 1].eulerAngles.z));
                }

            }

            sum = new Vector3(sum.x / listLength, sum.y / listLength, sum.z / listLength);
            Debug.Log(debugCount + "sum/listlength" + sum);
            sum = new Vector3(ReverseRot(sum.x), ReverseRot(sum.y), ReverseRot(sum.z));
            Debug.Log(debugCount + "nomalized" + sum);

            rem = rotMemory[0];
            rotMemory.RemoveAt(0);
            intCounter--;

            return sum;
        }
        else
            return Vector3.zero;
    }

    float AdjustRot(float before, float after)
    {
        float a = after;
        if (0 <= before && before <= 90)
        {
            if (180 <= after)
            {
                a -= 360;
                Debug.Log(debugCount + "adjust" + after + ", " + a);
            }
        }
        else if (270 <= before && before <= 360)
        {
            if (0 <= after && after <= 90)
            {
                a += 360;
                Debug.Log(debugCount + "adjust" + after + ", " + a);
            }
        }

        return a;
    }
    float ReverseRot(float a)
    {
        if (a > 360)
        {
            a -= 360;
        }
        else if (a < 0)
        {
            a += 360;
        }
        return a;
    }
}
