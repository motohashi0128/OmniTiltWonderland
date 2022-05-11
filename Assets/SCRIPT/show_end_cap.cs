using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class show_end_cap : MonoBehaviour
{
    float end_timer = 0;
    public int end_timer_int = 0;
    bool end_start = false;
    bool done = false;
    public GameObject targetcap;

    public GameObject target_endcamera;



    //string end_cap_text;

    public Text cout_text;

    // Start is called before the first frame update
    void Start()
    {
        targetcap.SetActive(false);
        //end_cap_text = targetcap.transform.Find("count_text").gameObject.GetComponent<Text>().text;

        //print(end_cap_text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            targetcap.SetActive(false);
            end_start = false;
            end_timer = 0;
        }

        if(end_start)
        {
            end_timer += Time.deltaTime;
            end_timer_int =  10-(int)end_timer;

            cout_text.text = end_timer_int + "秒後に自動的に移動します。";

            if (end_timer > 10.0f && !done)
            {
                targetcap.SetActive(false);
                target_endcamera.GetComponent<meta_camera_ctrl>().set_metamode();
                 
          
               
                
                
                //
                done = true;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !done)
        {
            other.gameObject.GetComponent<auto_return>().enable = false;
            other.gameObject.GetComponent<auto_return>().timer = 0;
            targetcap.SetActive(true);
            end_start = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !done)
        {
            other.gameObject.GetComponent<auto_return>().enable =  true;
            end_start = false;
            targetcap.SetActive(false);
            end_timer = 0;
            //Invoke("delay_hide", 2.0f);
        }
    }


    void delay_hide()
    {
        end_start = false;
        targetcap.SetActive(false);
        end_timer = 0;

    }
}
