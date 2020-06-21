using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject Ma;
    GameObject Mb;
    // Start is called before the first frame update
    void Start()
    {
        Ma = transform.Find("menu_background").gameObject;
        Mb=transform.Find("menu_etc").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Esc()
    {
        if (Time.timeScale == 1 )
        {
            Time.timeScale = 0;
            Ma.SetActive(true);
           
        }
        else
        {
            Time.timeScale = 1;
            Ma.SetActive(false);
            Mb.transform.GetChild(0).gameObject.SetActive(false);
            Mb.transform.GetChild(1).gameObject.SetActive(false);
            Mb.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void GO()
    {
        Time.timeScale = 1;
    }
}
