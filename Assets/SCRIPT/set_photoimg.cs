using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class set_photoimg : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject target_obj;
    public List<GameObject> harada_list = new List<GameObject>(); 

    void Start()
    {

        for (int i = 0; i < harada_list.Count; i++)
        {
            harada_list[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("h*.jpg") ;
        int ini_c = 0;
        foreach (FileInfo f in info)
        {
            
           // Debug.Log(f.Name);
            var texture = ReadTexture(Application.persistentDataPath + "/" +f.Name);
            Material _mat = harada_list[ini_c].GetComponent<Renderer>().material;
            _mat.mainTexture = texture;
            _mat.SetColor("_EmissionColor", new Color(1, 1, 1));
            _mat.SetTexture("_EmissionMap", texture);

            ini_c++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void setphotoimg_harada(int _count)  
    {
       string h_file_name = "h_"+_count;
        string r_path = Application.persistentDataPath +"/" +h_file_name + ".jpg";
        var texture = ReadTexture(r_path);

        Material _mat = harada_list[_count].GetComponent<Renderer>().material;
        _mat.mainTexture = texture;
        _mat.SetColor("_EmissionColor",  new Color (1,1,1));
        _mat.SetTexture("_EmissionMap", texture);
       
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
