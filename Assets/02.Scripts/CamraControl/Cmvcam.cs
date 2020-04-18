using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Cmvcam : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
