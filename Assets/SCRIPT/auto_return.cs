using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_return : MonoBehaviour
{
    // Start is called before the first frame update
    public bool  enable;
    bool act_enable = false;

    public float timer;
    float _limit = 30.0f;
    bool done = false;

    float m_x = 0.0f;
    float m_y = 0.0f;

    void Start()
    {
        //enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && enable)
        {
            act_enable = true;
            timer = 0;
        }

         m_x = Input.GetAxis("Mouse X");
         m_y = Input.GetAxis("Mouse Y");


        if (Mathf.Abs(m_x) > 0.05f)
        {
            print(" ugoita");
            timer = 0;

        }
        if (Mathf.Abs(m_y) > 0.05f)
        {
            print(" ugoita");
            timer = 0;

        }


        if (act_enable && enable)
        {
            timer += Time.deltaTime;
            if(timer > _limit && !done)
            {
                FadeManager.Instance.LoadScene("001_main", 2.0f);
                timer = 0;
            }


        }

        //print(timer);
    }
}
