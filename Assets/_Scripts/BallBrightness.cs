using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBrightness : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedMax,speedMin;
    Material mat;
    [SerializeField]
    float speed;
    [SerializeField]
    float heightBorderForBrightOff;
    [SerializeField]
    float Hue;
    [SerializeField]
    Color col;
    [SerializeField]
    int ListLength;
    List<float> speedsForAverage;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        speedsForAverage = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        if (transform.position.y < heightBorderForBrightOff)
            speed = 0;
        Debug.Log(speed);
        col = Color.HSVToRGB(Hue, SpeedAverage(SpeedNomalize(speed)), SpeedAverage(SpeedNomalize(speed)));
        Debug.Log(col);
        mat.SetColor("_EmissionColor", col);
    }
    float SpeedNomalize(float s)
    {
        float a;
        if (s > speedMax)
            return 1;
        else if (s < speedMin)
            return 0;
        else {
            a = s / speedMax;
            return a;
        }

    }

    float SpeedAverage(float s)
    {
        float a = 0;
        speedsForAverage.Add(s);
        if (speedsForAverage.Count < ListLength)
        {
            Debug.Log("リストが埋まっていません.");
            return 0;
        }
        if (speedsForAverage.Count >= ListLength)
        {
            a = 0;
            for (int i = 0; i < ListLength; i++)
            {
                a += speedsForAverage[i];
            }
            a = a / ListLength;
            
            speedsForAverage.RemoveAt(0);
        }
        return a;
    }
}
