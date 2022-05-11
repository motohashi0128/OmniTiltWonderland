 using UnityEngine;
using System.Collections;

public class new_hikoHD_ctrl : MonoBehaviour
{
    private Animator animator;
    private bool first_cam_flag = true;

    public bool first_cam_start = true;
    public Camera camera1;

    public IK_ctrl _ik_ctrl;
    //public Camera camera2;
    // public Camera camera3;

    Vector3 c3v;
    Vector3 tar_v;
    Quaternion c3q;
    Quaternion tar_q;

    public bool shootmode;
    bool _shoot_button;

    public bool FOTO = false;

    float _rota;
    float _rotaR, _rotaL;


    public float sensitivityX = 1.0F;
    public float sensitivityY = 1.0F;

    public float minimumX = -90F;
    public float maximumX = 90F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    float ik_target = 0.0f;
    float ik_current = 0.0f;

    new_hikoHD_first_cam _fcam;

    GameObject left_lk;
    GameObject left_lk_tar;

    Vector3 left_inipost;
    Vector3 left_cpos;
    Vector3 left_tpos;

    ctrl_iphone _ctrl_iphone;

    float ik_ease_speed;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        _ctrl_iphone = GetComponent<ctrl_iphone>();
        //GameObject.Find("thirdCamera").GetComponent<Camera>().enebled = false;
        //GameObject.Find("firstCamera").GetComponent<Camera>().enebled = true;

        camera1.GetComponent<Camera>().enabled = true;

        _ik_ctrl = GetComponent<IK_ctrl>();

        _fcam = GameObject.Find("FIRST_CAM").GetComponent<new_hikoHD_first_cam>();

         
        left_lk = GameObject.Find("left_hand_IK");
        left_lk_tar = GameObject.Find("left_hand_shoot_target");

        left_inipost = left_lk.transform.localPosition;

        left_cpos = left_lk.transform.localPosition;
        left_tpos = left_lk_tar.transform.localPosition;


      

        left_tpos = left_cpos;

        _shoot_button = false;


        ik_ease_speed =  80.0f;

        //left_tpos = left_cpos;
        /* 
        if (first_cam_start)
        {
            first_cam_flag = true;
            //camera3.GetComponent<Camera>().enabled = true;
            //camera2.GetComponent<Camera>().enabled = false;
            camera1.GetComponent<Camera>().enabled = false;
        }
        else
        {
            first_cam_flag = false;
            //camera3.GetComponent<Camera>().enabled = true;
            //camera2.GetComponent<Camera>().enabled = false;
            camera1.GetComponent<Camera>().enabled = false;
        };

        if (FOTO)
        {
            //camera3.GetComponent<Camera>().enabled = false;
            //camera2.GetComponent<Camera>().enabled = false;
            camera1.GetComponent<Camera>().enabled = true;
        }
        */
        /*
        c3v = camera3.transform.position;
        tar_v = camera2.transform.position;

        c3q = camera3.transform.rotation;
        tar_q = camera1.transform.rotation;
        */
        shootmode = false;
        _rotaR = 0.0f;
        _rotaL = 0.0f;
        _rota = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyUp ("c")) {
			if (!first_cam_flag) {
				first_cam_flag = true;
                camera2.GetComponent<Camera>().enabled = false;
                camera1.GetComponent<Camera>().enabled = true;
			} else {
				first_cam_flag = false;
                camera2.GetComponent<Camera>().enabled = true;
                camera1.GetComponent<Camera>().enabled = false;
			}
		}
        */

        //print(Mathf.Abs(Input.GetAxis("Horizontal_2")));
        /*
        if (Mathf.Abs(Input.GetAxis("Horizontal_2")) > 0.1f)
        {
            _rota = Input.GetAxis("Horizontal_2");
            if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f)
            {
                animator.SetBool("Rotate", true);
            }
            else
            {
                animator.SetBool("Rotate", false);
            }

        }
        else
        {
            _rota = 0.0f;
            animator.SetBool("Rotate", false);
        }

        if (Input.GetAxis("Horizontal_2") > 0.1f)
        {
            _rotaR = Mathf.Abs(Input.GetAxis("Horizontal_2"));
        }
        else
        {
            _rotaR = 0.0f;
        }

        if (Input.GetAxis("Horizontal_2") < -0.1f)
        {
            _rotaL = Mathf.Abs(Input.GetAxis("Horizontal_2"));
        }
        else
        {
            _rotaL = 0.0f;
        }
        */

        if (!animator.GetBool("Rotate"))
        {
            this.gameObject.transform.Rotate(0, (_rota * 2.0f), 0);
        }

        /*
        if (Input.GetKeyUp("v") || Input.GetKeyUp("b"))
        {
            
            if (!FOTO)
            {
                camera3.GetComponent<Camera>().enabled = true;
                camera2.GetComponent<Camera>().enabled = false;
                camera1.GetComponent<Camera>().enabled = false;
                Cursor.visible = false;
            }
            shootmode = true;
        }
    */

        if (shootmode)
        {
            tar_v = camera1.transform.position;
            tar_q = camera1.transform.rotation;
        }
        else
        {
            ik_target = 0.0f;
            //tar_v = camera2.transform.position;
            //tar_q = camera2.transform.rotation;
        }


        ik_current += (ik_target - ik_current) / ik_ease_speed;
        _ik_ctrl._ikWeight = ik_current;
        //tar_v = camera3.transform.position;

        //c3v += (tar_v - c3v) / 10.0f;


        //c3q = tar_q;
        //c3q = (tar_q * Quaternion.Inverse(c3q));

        //c3q = new Quaternion(c3q.x, c3q.y, c3q.z, c3q.w);
        // camera3.transform.position = c3v;
        //camera3.transform.rotation = c3q;



        animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

        animator.SetFloat("Rota_R", _rotaR);
        animator.SetFloat("Rota_L", _rotaL);
        animator.SetFloat("Rota", _rota);

        //print (Input.GetAxis ("Vertical"));
        //print (Input.GetAxis ("Horizontal"));

        //print(Input.mousePosition.y);

        if (Input.GetButtonDown("Jump"))
        {
            //animator.SetBool ("jumping", true);
            //Invoke ("StopJumping", 0.1f);
        }

        if (Input.GetKey("p"))
        {
            animator.SetBool("Punch", true);
            Invoke("StopPunch", 0.1f);
        }

        if (Input.GetKey("a"))
        {
            if ((Input.GetAxis("Vertical") == 0.0f) /*&& (Input.GetAxis ("Horizontal") == 0.0f)*/)
            {
                animator.SetBool("turnL", true);
            }
        }
        else
        {
            animator.SetBool("turnL", false);
        }


        if (Input.GetKey("d"))
        {
            if ((Input.GetAxis("Vertical") == 0.0f) /*&& (Input.GetAxis ("Horizontal") == 0.0f)*/)
            {
                animator.SetBool("turnR", true);
            }
        }
        else
        {
            animator.SetBool("turnR", false);
        }


        if (Input.GetAxis("Horizontal") < -0.3)
        {
            if ((Input.GetAxis("Vertical") == 0.0f) /*&& (Input.GetAxis ("Horizontal") == 0.0f)*/)
            {
                animator.SetBool("turnL", true);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0.0)
        {
            animator.SetBool("turnL", false);
        }

        if (Input.GetAxis("Horizontal") > 0.3)
        {
            if ((Input.GetAxis("Vertical") == 0.0f) /*&& (Input.GetAxis ("Horizontal") == 0.0f)*/)
            {
                animator.SetBool("turnR", true);
            }
        }
        else if (Input.GetAxis("Horizontal") > 0.0)
        {
            animator.SetBool("turnR", false);
        }



        if (Input.GetKey("w") && Input.GetKey("left shift") || Input.GetKey("w") && Input.GetKey("right shift") || Input.GetKey("up") && Input.GetKey("left shift"))
        {
            if ((Input.GetAxis("Vertical") > 0.5f) && (Input.GetAxis("Horizontal") == 0.0f))
            {
                //animator.SetBool("Running", true);
            }
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            //transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
        }
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            //transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
        }

        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            //transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
        }
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            //transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
        }

        if (Input.GetKeyUp("c") && shootmode == false)
        {
            animator.SetBool("shoot", true);
            //shootmode = true;
            //Invoke("StopShoot", 8.0f);
            Invoke("setDelayIkweight", 2.5f);
            setDelayCamshootmode_true();
            Invoke("setDelayCamshootmode_false", 4.3f);


        }
        else if (Input.GetKeyUp("c") && shootmode == true)
        {
            animator.SetBool("shoot", false);
            setDelayCamshootmode_false();
            Invoke("setDelayIkweight_zero", 2.5f);
            Invoke("hide_iphone_delay", 3.0f);
            //shootmode = false;
        }

        if (Input.GetKeyUp("v") && shootmode == false)
        {
            animator.SetBool("shoot", true);
            //shootmode = true;
            //Invoke("StopShoot", 8.0f);
            Invoke("setDelayIkweight", 2.5f);
            setDelayCamshootmode_true();
            Invoke("setDelayCamshootmode_false", 4.3f);

        }else if (Input.GetKeyUp("v") && shootmode == true)
        {
            animator.SetBool("shoot", false);
            setDelayCamshootmode_false();
            Invoke("setDelayIkweight_zero", 2.5f);
            Invoke("hide_iphone_delay", 3.0f);

            //shootmode = false;
        }
        if (Input.GetKeyUp("b") && shootmode == false)
        {
            animator.SetBool("shoot", true);
            //shootmode = true;
            //Invoke("StopShoot", 8.0f);
            Invoke("setDelayIkweight", 2.5f);
            setDelayCamshootmode_true();
            Invoke("setDelayCamshootmode_false", 4.3f);

        }
        else if (Input.GetKeyUp("b") && shootmode == true)
        {
            animator.SetBool("shoot", false);
            setDelayCamshootmode_false();
            Invoke("setDelayIkweight_zero", 2.5f);
            Invoke("hide_iphone_delay", 3.0f);

           //shootmode = false;
        }


        if (Input.GetMouseButtonUp(0) && shootmode == true)
        {
            animator.SetBool("shoot_button", true);
            _shoot_button = true;
            push_shoot();
            _ctrl_iphone.send_photocam.SetActive(true);

            Invoke("delay_shootfunc", 1.0f);

        }

        /*
        if (Input.GetButtonDown("Fire1"))
        {
            print("fire1");
            animator.SetBool("shoot", true);
            shootmode = true;
            Invoke("StopShoot", 8.0f);
        }*/
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            print("fire2");
            animator.SetBool("shoot", true);
            shootmode = true;
            Invoke("StopShoot", 8.0f);
        }*/
        /*
        if (Input.GetButtonDown("Fire3"))
        {
            print("fire3");
            animator.SetBool("shoot", true);
            shootmode = true;
            Invoke("StopShoot", 8.0f);
        }
        */

        //

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);


        if (_shoot_button)
        {
            

        }else{
            

        }

        Vector3 diff = left_tpos - left_cpos;
        Vector3 v = diff * 0.1f;
        left_cpos += v;

        if (diff.magnitude < 0.01f)
        {
            _shoot_button = false;
            left_tpos = left_inipost;
            animator.SetBool("shoot_button", false);


        }

        left_lk.transform.localPosition = left_cpos;

        //print(left_cpos);
        //left_cpos
        //print(rotationX);

        //print(Input.GetKey());
    }

    void setDelayIkweight(){
        shootmode = true;
        ik_target = 0.9f;
        ik_ease_speed = 80.0f;
    }
    void setDelayIkweight_zero()
    {
        shootmode = false;
        ik_target = 0.0f;
        ik_ease_speed = 10.0f;
    }
    void setDelayCamshootmode_false()
    {
        _fcam._shootmode = false;
    }
    void setDelayCamshootmode_true()
    {
        _fcam._shootmode = true;
        print("call");

    }
    void hide_iphone_delay(){
        _ctrl_iphone.hide_iphone();
    }

    void push_shoot(){
        left_tpos = left_lk_tar.transform.localPosition;

    }
    void delay_shootfunc(){
        _ctrl_iphone.shoot_iphone();
    }
    void StopJumping()
    {

        animator.SetBool("jumping", false);
    }
    void StopPunch()
    {

        animator.SetBool("Punch", false);
    }

    void StopShoot()
    {

        animator.SetBool("shoot", false);
    }

    void SelectCamera(int cameraIndex)
    {


    }
}
