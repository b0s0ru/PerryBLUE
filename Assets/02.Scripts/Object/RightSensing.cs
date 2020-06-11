using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSensing : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform j;
    bool s = false;
    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.gameObject.tag == "Mpos" && s==false)
        {
            s = true;
            j.transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    

}
