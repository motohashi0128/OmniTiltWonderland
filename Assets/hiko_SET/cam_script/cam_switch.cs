using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cam_switch : MonoBehaviour
{

    private float fadeAlpha = 0;
    /// <summary>フェード中かどうか</summary>
    private bool isFading = false;
    /// <summary>フェード色</summary>
    public Color fadeColor = Color.black;
    public List<GameObject> n_cams;
    public int current_cam_num;
    GameObject main_cam;
    GameObject text_area;

    GameObject text_skip;

    new_hikoHD_ctrl hiko;

    void Start()
    {
        main_cam = GameObject.Find("FIRST_CAM");
        text_area = GameObject.Find("n_text");
        text_skip = GameObject.Find("Skip");
        text_skip.SetActive(false);

        hiko = GameObject.Find("hiko_HD").GetComponent<new_hikoHD_ctrl>();


        for (int i = 0; i < n_cams.Count; i++)
        {
            n_cams[i].SetActive(false);
        }
        current_cam_num = 99;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 
        public void cam_hide(){
            for(int i=0; i < n_cams.Count; i++){
                n_cams[i].SetActive(false);
            }
        }
        */
    public void OnGUI()
    {
        // Fade .
        if (this.isFading)
        {
            //色と透明度を更新して白テクスチャを描画 .
            this.fadeColor.a = this.fadeAlpha;
            GUI.color = this.fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }

    public void cam_active(int num)
    {
        StopAllCoroutines();
        StartCoroutine(cam_change(num));
    }

    public void cam_hide(int camnum)
    {
        StopAllCoroutines();
        StartCoroutine(back_to_main());

    }
    public IEnumerator cam_change(int num)
    {
        this.isFading = true;
        float time = 0;
        float interval = 0.25f;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        for (int i = 0; i < n_cams.Count; i++)
        {
            n_cams[i].SetActive(false);
        }
				
        current_cam_num = num;
        n_cams[num].SetActive(true);

        text_skip.SetActive(true);
        time = 0;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        this.isFading = false;

    }
    public IEnumerator back_to_main()
    {


        this.isFading = true;
        float time = 0;
        float interval = 0.25f;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        for (int i = 0; i < n_cams.Count; i++)
        {
            n_cams[i].SetActive(false);
        }

        text_area.GetComponent<Text>().text = "";
        text_skip.SetActive(false);
        main_cam.SetActive(true);

        time = 0;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        this.isFading = false;
        //StopAllCoroutines();
        //CancelInvoke();

    }

}
