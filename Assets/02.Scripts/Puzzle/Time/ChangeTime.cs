using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour
{
    public int a;

    private Image s;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame


    public void Up()
    {
        a++;
        if (a == 12)
        {
            a = 0;
        }
        //Change();
    }

    void Update()
    {

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -(a * 30)));
    }
}