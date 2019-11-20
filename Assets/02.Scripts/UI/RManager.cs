using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas/Script").transform.Find("UI_normal_script").gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
