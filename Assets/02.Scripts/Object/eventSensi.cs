using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSensi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Textload()
    {

        GameObject.Find("Canvas/GameObject").transform.Find("1_manual").gameObject.SetActive(true);



        

    }
    
    
}
