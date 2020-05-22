using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Cmvcam : MonoBehaviour
{
    CinemachineVirtualCamera r;
    Transform u;
    bool Camerabig;
   // Transform d;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<CinemachineVirtualCamera>();
        u = GameObject.Find("Player").transform.Find("CameraPoint").GetComponent<Transform>();
   //     d = GameObject.Find("Player").transform.Find("DownCameraPoint").GetComponent<Transform>();
        r.Follow =u;
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.C) && Camerabig == false)
            {

                r.m_Lens.FieldOfView = 120;
                Camerabig = true;
            }
            if (Input.GetKeyUp(KeyCode.C) && Camerabig)
            {

                r.m_Lens.FieldOfView = 90;
                Camerabig = false;
            }
        }
       */
    }
  /*  void UP()
    {
        r.Follow = u;
    }
    void Down()
    {
        r.Follow = d;
    }*/
}
