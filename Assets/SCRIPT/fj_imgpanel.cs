using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

 

public class fj_imgpanel : MonoBehaviour
{
    float slide_time;
    int slide_count = 0;
    // Start is called before the first frame update

    public int fujikura_t_max = 9;


    public List<Texture> fj_texs = new List<Texture>();

     public Material target_mat;
     

    Material _mat;
    void Start()
    {

        target_mat.EnableKeyword("_EMISSION");
        target_mat.SetColor("_EmissionColor", new Color(1, 1, 1));

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("f*.jpg");
        int ini_c = 0;
        foreach (FileInfo f in info)
        {

//            Debug.Log(f.Name);
            var texture = ReadTexture(Application.persistentDataPath + "/" + f.Name);

            fj_texs.Add(texture);

           
            ini_c++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        slide_time += Time.deltaTime;
         if(slide_time> 3.0f)
        {
            if(fj_texs.Count > 0)
            {
                slide_count++;
                if(slide_count > fj_texs.Count-1)
                {
                    slide_count = 0;
                }

                target_mat.mainTexture = fj_texs[slide_count];
                target_mat.SetTexture("_EmissionMap", fj_texs[slide_count]);

            }
            slide_time = 0.0f;
        }
          if (Input.GetKey(KeyCode.R))
        {
            //reload_img();
        }
    }


     public void reload_img()
    {

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("f*.jpg");
        int ini_c = 0;
        fj_texs.Clear();
        foreach (FileInfo f in info)
        {

            Debug.Log(f.Name);
            var texture = ReadTexture(Application.persistentDataPath + "/" + f.Name);

            fj_texs.Add(texture);

            
            ini_c++;
        }
    }

    Texture ReadTexture(string path)
    {
        byte[] readBinary = ReadFile(path);

        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(readBinary);

        return texture;
    }
    byte[] ReadFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }
}
