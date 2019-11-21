using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public int a;
    static TextLoader s;
    public bool [] d;
    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("UI_Script/TextManager").gameObject.GetComponent<TextLoader>();
        a = a - 2;
        d[0] = false;
        d[1] = false;
        d[2] = false;
        d[3] = false;
        d[4] = false;
        d[5] = false;
    }
    private void Update()
    {
       
        s.Allclear = true;
        for (int i = 0; i < d.Length; i++)
        {

            if (!d[i])
            {
                s.Allclear = false;
            }
        }

    }
    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mpos" && Input.GetKey(KeyCode.UpArrow))
        {
            s.Settings();

        }

    }
}
