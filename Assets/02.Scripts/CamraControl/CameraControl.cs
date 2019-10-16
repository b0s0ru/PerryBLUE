using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform target;
   
    private Vector3 offset;
    public float CameraZ = -10;
    // Start is called before the first frame update
    void Start()
    {

        GetTarget();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime*2);

      
    }
    
    void GetTarget()
    {
        GameObject obj = GameObject.Find("Player/CameraPoint");

        if (obj) target = obj.transform;
    }
}
