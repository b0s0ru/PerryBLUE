using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update

    static Rigidbody2D a;
    static Player b;
    public bool s;
    Transform t;
    GameObject q;
    private void Start()
    {
        t = GetComponent<Transform>();
        a = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        b=GameObject.Find("Player").GetComponent<Player>();
        q = transform.GetChild(0).gameObject;
        if (s)
        {

            q.SetActive(true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            q.SetActive(false);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.transform.tag == "HandPos")
        {

           
            b.Jenu(s,gameObject);
            a.WakeUp();
          

        }
    }

    public void Change()
    {
        if (s)
        {
            q.SetActive(false);
            s = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
           q.SetActive(true);
            s = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

      
    }
}
