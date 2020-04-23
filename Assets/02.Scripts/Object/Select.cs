using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    // Start is called before the first frame update
    public int a;
    static TextLoader s;
    void Start()
    {
        s = GameObject.Find("UI_Script/TextManager").gameObject.GetComponent<TextLoader>();
        a = a - 2;
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {

            s.ObjectsWork2(a);

        }

    }
}

