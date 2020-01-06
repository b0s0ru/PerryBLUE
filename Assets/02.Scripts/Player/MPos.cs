using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPos : MonoBehaviour
{
    Player a;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame


    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Object" && Input.GetKey(KeyCode.UpArrow)&& a.isperry==false)
        {
            
            other.gameObject.SendMessage("Textload");
        }
    }
}

