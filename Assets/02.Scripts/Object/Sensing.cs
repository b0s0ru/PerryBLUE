using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensing : MonoBehaviour
{
    // Start is called before the first frame update
    public int a;
    static TextLoader s;
   
   
    private void Awake()
    {
        s = GameObject.Find("UI_Script/TextManager").gameObject.GetComponent<TextLoader>();
       
        a = a-2;
    }
    public void Textload()
    {
       
           // s.ObjectsWork(a);

       
    }
}
