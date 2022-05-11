using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ctrl_iphone : MonoBehaviour {
	private Animator animator;

    public bool photo_tenji_mode;

	public GameObject iphone;
	public GameObject iphone_screen;

	private AudioSource iphone_shoot_source;

	public GameObject send_photocam;
	//public GameObject send_photocam_screen;


	public RenderTexture save_image;

    bool key_wait;

    bool cam_front;

    new_hikoHD_ctrl hiko_Ctrl;

    GameObject main_cam;
    GameObject send_cam;

    public GameObject web_screen;

    Quaternion cam_rot;

    public bool save_file = false;

    //public bool web_cam_save = false;

    string save_path;
    string m_Path;
    string fileName;

    int shoot_count;
    string s_filename;

    int t_count = 0;
    int fj_count = 0;
    string t_filename;
    //public int t_maxcount;
    public int fujikura_max = 9; 
    public string full_filepath;

    public bool harada_mode = false;
    public bool fujikura_mode = false;

    public GameObject oyaizu_slide;

    private void Awake()
    {
        main_cam = GameObject.Find("iphone_cam");
        send_cam = GameObject.Find("send_image");
        hiko_Ctrl = GameObject.Find("hiko_HD").GetComponent<new_hikoHD_ctrl>();
        animator = GameObject.Find("hiko_HD").GetComponent<Animator>();
        iphone_shoot_source = this.GetComponent<AudioSource>();
        
    }
    // Use this for initialization
    void Start () {
        main_cam = GameObject.Find("iphone_cam");
        send_cam = GameObject.Find("send_image");
        hiko_Ctrl = GameObject.Find("hiko_HD").GetComponent<new_hikoHD_ctrl>();
		animator = GameObject.Find("hiko_HD").GetComponent<Animator> ();
		iphone_shoot_source = this.GetComponent<AudioSource> ();
        
		iphone.SetActive (false);
		iphone_screen.SetActive (false);
		send_photocam.SetActive (false);
		//send_photocam_screen.SetActive (false);
        key_wait = false;
        cam_front = true;

        web_screen.SetActive(false);

        shoot_count = PlayerPrefs.GetInt("S_COUNT");
        if (shoot_count == 0)
        {
            shoot_count = 1;
        }


//        t_maxcount = GetComponent<set_photoimg>().harada_list.Count;

        fj_count = check_fj_cout();
        if(fj_count> fujikura_max)
        {
            fj_count = 0;
        }
        print(fj_count);
       // cam_rot = main_cam.transform.rotation;
    }

	// Update is called once per frame
	void Update () {

       

        if (Input.GetKeyUp(KeyCode.C) && !key_wait)
        {
            key_wait = true;
            print("key_c");
            web_screen.SetActive(false);

            Invoke("show_iphone", 2.0f);
        

                cam_front = true;
           

            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else{
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
		}
         
        if (Input.GetKeyUp(KeyCode.V) && !key_wait)
        {
            key_wait = true;
            print("key_v");
            web_screen.SetActive(false);

            Invoke("show_iphone", 2.0f);
            //Invoke("shoot_iphone", 7.0f);
            //Invoke("hide_iphone", 10.0f);


            cam_front =  false;


            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
        }
         
        //webcam
        
        if (Input.GetKeyUp(KeyCode.B) && !key_wait)
        {
            key_wait = true;
            //print("key");
            web_screen.SetActive(true);
            Invoke("show_iphone", 2.0f);
            //Invoke("shoot_iphone", 7.0f);
            //Invoke("hide_iphone", 10.0f);



            cam_front = false;


            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, -90);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, -90);
            }
            else
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, -90);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, -90);
            }
        }
        

        //webcam
        /*
        if (Input.GetButtonDown("Fire2") && !key_wait)
        {
            key_wait = true;
            //print("key");
            web_screen.SetActive(true);
            Invoke("show_iphone", 2.0f);
            Invoke("shoot_iphone", 7.0f);
            Invoke("hide_iphone", 10.0f);



            cam_front = false;


            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
        }
        */
        /*
        if (Input.GetButtonDown("Fire1")&& !key_wait)
        {
            key_wait = true;
            print("key");
            web_screen.SetActive(false);

            //Invoke("show_iphone", 2.0f);
            //Invoke("shoot_iphone", 7.0f);
            //Invoke("hide_iphone", 10.0f);


            cam_front = true;


            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
        }
        */
        /*
        if (Input.GetButtonDown("Fire3")&& !key_wait){
            key_wait = true;
            //print("key");
            web_screen.SetActive(false);

            Invoke("show_iphone", 2.0f);
            Invoke("shoot_iphone", 7.0f);
            Invoke("hide_iphone", 10.0f);

            cam_front = false;

            if (cam_front)
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else
            {
                main_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                send_cam.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
        }


        */

        //cam_rot = 
        //main_cam.transform.rotation = Quaternion.Euler(0, 90f, 0); ;
        //send_cam.transform.rotation = cam_rot;
	}

	void show_iphone(){
		iphone.SetActive (true);
		iphone_screen.SetActive (true);

	}

	public void shoot_iphone(){

        if(!iphone_shoot_source.isPlaying ){
            send_photocam.SetActive(true);
            iphone_shoot_source.Play();

            if (shoot_count < 10)
            {
                s_filename = "IMG_000" + shoot_count;
            }
            if (shoot_count > 9 && shoot_count < 100)
            {
                s_filename = "IMG_00" + shoot_count;
            }
            if (shoot_count > 99 && shoot_count < 1000)
            {
                s_filename = "IMG_0" + shoot_count;
            }
            if (shoot_count > 999 && shoot_count < 10000)
            {
                s_filename = "IMG_" + shoot_count;
            }
            /*
            string m_Path = Application.dataPath+"/../../";
            string fileName = System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + ".png";
            //SaveRenderTextureToJpg (save_image,"/data");
            */

            // print(s_filename);

            
            

            if (web_screen.activeSelf)
            {
                string m_Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                fileName = s_filename + ".jpg";
                ScreenCapture.CaptureScreenshot(m_Path + "/"  + fileName, 1);
            }
            else
            {
                SaveRenderTextureToJpg(save_image, "");

            }
            shoot_count++;
            PlayerPrefs.SetInt("S_COUNT", shoot_count);

            if (save_file)
            {
                //ScreenCapture.CaptureScreenshot(m_Path + "selfie_" + fileName, 1);
            }

		}

		//send_photocam_screen.SetActive (true);
		Invoke ("hide_send_photocam",0.2f);
		

	}


	void hide_send_photocam(){
		send_photocam.SetActive (false);
		Invoke ("hide_send_photocam_screen",10.0f);

	}

	void hide_send_photocam_screen(){
		//send_photocam_screen.SetActive (false);

	}

	public void hide_iphone(){
        key_wait = false;
		iphone.SetActive (false);
		iphone_screen.SetActive (false);

        hiko_Ctrl.shootmode = false;
	}


    /*
     void set_texture_obj()
    {
        GetComponent<set_photoimg>().setphotoimg_harada(t_count);
        t_count += 1;
        if (t_count > t_maxcount - 1)
        {
            t_count = 0;
        }
    }
    */


    void set_fj_img()
    {
        oyaizu_slide.GetComponent<fj_imgpanel>().reload_img();
    }
     int check_fj_cout()
    {

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("f*.jpg");
        int ini_c = 0;
        foreach (FileInfo f in info)
        {
//            Debug.Log(f.Name);          
            ini_c++;
        }
        return ini_c;
    }


    private void SaveRenderTextureToJpg(RenderTexture RenderTextureRef, string saveFilePath)
    {
        Texture2D tex = new Texture2D(RenderTextureRef.width, RenderTextureRef.height, TextureFormat.RGB24, false);
        RenderTexture.active = RenderTextureRef;
        tex.ReadPixels(new Rect(0, 0, RenderTextureRef.width, RenderTextureRef.height), 0, 0);
        tex.Apply();

        if (s_filename == "tmp")
        {
           // Graphics.Blit(tex, take_webcam_image);
            //take_webcam_image = tex;
        }

        // Encode texture into PNG
        //byte[] bytes = tex.EncodeToPNG();
        byte[] bytes = tex.EncodeToJPG();
        UnityEngine.Object.Destroy(tex);

        //




#if UNITY_EDITOR
        // string path = EditorUtility.SaveFilePanel("choose save directory", "", "", "png");

        //ES2.SaveImage(GetComponent<Renderer>().material.mainTexture, "C:/Users/User/MyImage.png");

        //string m_Path = Application.dataPath + "/../photo/";
        string m_Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        print(m_Path);
        //fileName = System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + ".jpg";


        fileName = s_filename + ".jpg";
        //saveFilePath = Directory.GetCurrentDirectory();

#else
         //string m_Path = Application.dataPath + "/../../photo/";
        //string m_Path = Application.dataPath+"/../../";
        string m_Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        fileName = s_filename + ".jpg";

         //m_Path = save_path;
         //fileName = System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + ".jpg";
        // saveFilePath = Application.persistentDataPath;
#endif

        if (!photo_tenji_mode)
        {
            File.WriteAllBytes(m_Path + "/" + fileName, bytes);

        }
        else
        {
            File.WriteAllBytes(m_Path + "/photo/" + fileName, bytes);

        }

        //
        if (harada_mode)
        {
            t_filename = "h_"+t_count + ".jpg";
            File.WriteAllBytes(Application.persistentDataPath + "/" + t_filename, bytes);

            //print(Application.persistentDataPath);

            Invoke("set_texture_obj", 0.5f);
        }

         if(fujikura_mode)
        {
            t_filename = "f_" + fj_count + ".jpg";
            File.WriteAllBytes(Application.persistentDataPath + "/" + t_filename, bytes);

            Invoke("set_fj_img", 0.5f);

            fj_count++;
             if(fj_count > fujikura_max)
            {
                fj_count = 0;
            }
        }
        //Write to a file in the project folder
        //File.WriteAllBytes(saveFilePath, bytes);
    }

}
