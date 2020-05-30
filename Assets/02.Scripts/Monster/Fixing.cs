using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixing : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    bool change = false;
    Transform s;
    void Start()
    {
        s = transform.parent.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = s.localScale.x;
        if (x == 1 && change==true)
        {

            change = false;
            gameObject.transform.GetComponent<Transform>().localScale = new Vector2(1,1);
        }
        else if(x== -1 && change==false)
        {
            change = true;
            gameObject.transform.GetComponent<Transform>().localScale = new Vector2(-1,1);
        }
    }
}
