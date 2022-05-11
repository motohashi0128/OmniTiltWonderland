using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hit_test_multi : MonoBehaviour
{
    GameObject main_cam;
    public int cam_num;

    public int wainting_time = 10;
    // Start is called before the first frame update
    [Multiline(3)]
    public string show_text;
    [Multiline(3)]
    public List<string> show_texts;

    int rand_text;
    GameObject text_area;
    new_hikoHD_ctrl hiko;

    ctrl_iphone hikophone;
    cam_switch cam_Switch;


    Animator hiko_anim;
    void Start()
    {
        main_cam = GameObject.Find("FIRST_CAM");
        cam_Switch = GameObject.Find("cams_ctrl").GetComponent<cam_switch>();
        text_area = GameObject.Find("n_text");
        hiko = GameObject.Find("hiko_HD").GetComponent<new_hikoHD_ctrl>();
        hiko_anim = GameObject.Find("hiko_HD").GetComponent<Animator>();
        hikophone = GameObject.Find("hiko_HD").GetComponent<ctrl_iphone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            CancelInvoke();
            if (hiko.enabled == false)
            {
                CancelInvoke();
                backtomain();
                hide_text();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag);
        //print(cam_Switch.current_cam_num);
        if (other.gameObject.tag == "Player")
        {
            if (cam_num != cam_Switch.current_cam_num)
            {
                //main_cam.SetActive(false);
                cam_Switch.cam_active(cam_num);
                hiko_anim.SetFloat("VSpeed", 0);
                hiko_anim.SetFloat("HSpeed", 0);
                hiko_anim.SetFloat("Rota", 0);
                hiko.enabled = false;
                hikophone.enabled = false;
                Invoke("set_text", 1.0f);
                Invoke("backtomain", wainting_time);
            }
        }
    }

    void set_text()
    {
        rand_text = Random.Range(0, show_texts.Count);
        text_area.GetComponent<Text>().text = show_texts[rand_text];
    }
    void hide_text()
    {
        text_area.GetComponent<Text>().text = "";
    }

    void backtomain()
    {
        cam_Switch.cam_hide(cam_num);
        hiko.enabled = true;
        hikophone.enabled = true;
    }
}
