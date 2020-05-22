using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Esc()
    {
            Time.timeScale = 0;
            transform.Find("UI_menu").gameObject.SetActive(true);
        
    }
    public void GO()
    {
        Time.timeScale = 1;
    }
}
