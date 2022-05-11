using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenji_settings : MonoBehaviour
{
    public bool tenji_mode = false;

    public GameObject hikohiko;

    public GameObject ending_notepc;

    public List<GameObject> tenji_hide = new List<GameObject>();
    public List<GameObject> tenji_show = new List<GameObject>();
 
    // Start is called before the first frame update
    void Start()
    {
        if (!tenji_mode)
        {
            hikohiko.GetComponent<auto_return>().enable = false;
            hikohiko.GetComponent<ctrl_iphone>().photo_tenji_mode = false;
            ending_notepc.GetComponent<quit_function>().icc_kannai = false;

            for (int i=0; i < tenji_show.Count; i++)
            {
                tenji_show[i].SetActive(false);
            }

            for (int i = 0; i < tenji_hide.Count; i++)
            {
                tenji_hide[i].SetActive(true);
            }

        }
        else if (tenji_mode)
        {
            hikohiko.GetComponent<auto_return>().enable = true;
            hikohiko.GetComponent<ctrl_iphone>().photo_tenji_mode = true;
            ending_notepc.GetComponent<quit_function>().icc_kannai = true;

            for (int i = 0; i < tenji_show.Count; i++)
            {
                tenji_show[i].SetActive(true);

            }

            for (int i = 0; i < tenji_hide.Count; i++)
            {
                tenji_hide[i].SetActive(false);
 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
