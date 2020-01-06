using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensing : MonoBehaviour
{
    // Start is called before the first frame update
    public int a;
    static TextLoader s;
   
    bool q = true;
    private void Awake()
    {
        s = GameObject.Find("UI_Script/TextManager").gameObject.GetComponent<TextLoader>();
       
        a = a-2;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {
            s.ObjectsWork(a);
          
        }

    }
}
