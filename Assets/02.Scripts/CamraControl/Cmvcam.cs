using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Cmvcam : MonoBehaviour
{
    CinemachineVirtualCamera r;
    Transform u;
    Transform d;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<CinemachineVirtualCamera>();
        u = GameObject.Find("Player").transform.Find("CameraPoint").GetComponent<Transform>();
        d = GameObject.Find("Player").transform.Find("DownCameraPoint").GetComponent<Transform>();
        r.Follow =u;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UP()
    {
        r.Follow = u;
    }
    void Down()
    {
        r.Follow = d;
    }
}
