using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldEvent : MonoBehaviour
{
    public void OnValueChanged()
    {
        string value = this.GetComponent<InputField>().text;
        if (value.IndexOf("\n") != -1)
        {
            print("kaigyo");
            this.GetComponent<InputField>().text = value.Trim('\r', '\n');
        }
    }
    /*
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string value = this.GetComponent<InputField>().text;
            this.GetComponent<InputField>().text = value.Trim('\r', '\n');

            if (value.IndexOf("\n") != -1)
            {
                print("kaigyo");
                this.GetComponent<InputField>().text = value.Trim('\r', '\n');
            }
        }

    }
    */
        
}