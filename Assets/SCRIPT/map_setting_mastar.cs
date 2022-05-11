using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class map_setting_mastar : MonoBehaviour
{

    public GameObject _enter;
    public GameObject _leave;

    public bool enter_map = false;

    public GameObject map_light;
    public GameObject post_process;

    float tar_alp = 0.1f;
    float fog_alp = 0.1f;

    float tar_w = 1.0f;
    float post_w = 1.0f;

    float l_tar = 0.0f;
    float l_inten = 0.0f;

    public GameObject bgm1;
    public GameObject bgm2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter_map)
        {
            tar_alp = 0.0f;
            tar_w = 0.1f;
            l_tar = 4.5f;
        }
        if (!enter_map)
        {
            tar_alp = 0.1f;
            tar_w = 1.0f;
            l_tar =  0.0f;
        }
        fog_alp += (tar_alp - fog_alp) / 100.0f;
        post_w += (tar_w - post_w) / 100.0f;

        l_inten += (l_tar - l_inten) / 100.0f;
        
        if (enter_map && post_w < 0.1f)
        {
            post_w = 0.1f;
        }

        if (!enter_map && post_w > 0.999f)
        {
            post_w = 1;
        }
        
        bgm1.GetComponent<AudioSource>().volume = post_w;
        bgm2.GetComponent<AudioSource>().volume = 1.0f - post_w;

        map_light.GetComponent<Light>().intensity = l_inten;
        RenderSettings.fogDensity = fog_alp;
        post_process.GetComponent<PostProcessVolume>().weight = post_w;
    }
}
