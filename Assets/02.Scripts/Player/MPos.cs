using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPos : MonoBehaviour
{
    Player a;
    bool yes = false;
    Collider2D others;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame


    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Object"){
        yes = true;
        others = other;
        a.GetComponent<Rigidbody2D>().WakeUp();
        }
     
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            yes = false;
        }
    }


    void Update()
    {


        if (yes)
        {
            if (others.gameObject.tag == "Object" && Input.GetKey(KeyCode.UpArrow) && a.isperry == false && a.stop == false)
            {
                a.stop = true;

                others.gameObject.SendMessage("Textload");
            }
        }

            
        
    }
    
}

