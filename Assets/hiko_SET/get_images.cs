using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class get_images : MonoBehaviour
{
    // Start is called before the first frame update

    public float intarval_time = 10.0f;
    float counter = 0.0f;
    void Start()
    {
        change_texture();
        //photo_img = ReadTexture(FileInfo[0], 1080, 1920);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(counter > intarval_time){
            counter = 0.0f;

            change_texture();
        }
    }

    void change_texture(){
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/../photo");
        FileInfo[] info = dir.GetFiles("*.png");
        foreach (FileInfo f in info)
        {
            Debug.Log(f.Name);

        }
        if (info.Length > 0)
        {
            GetComponent<Renderer>().material.mainTexture = ReadTexture(info[info.Length - 1].FullName, 1080, 1920);
        }

    }        


    byte[] ReadPngFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

    Texture ReadTexture(string path, int width, int height)
    {
        byte[] readBinary = ReadPngFile(path);

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }

}
