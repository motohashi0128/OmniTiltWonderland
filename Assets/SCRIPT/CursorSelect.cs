using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSelect : MonoBehaviour
{
    public Texture2D handCursor;


    
    void Start()
        {
        　　　Cursor.visible = false;
             Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }
    
}